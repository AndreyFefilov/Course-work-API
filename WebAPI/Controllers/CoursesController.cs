using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Models;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _repos;
        private readonly DataContext _context;

        public CoursesController(ICoursesRepository repos, DataContext context)
        {
            _repos = repos;
            _context = context;
        }

        [HttpPost("create-course")]
        public async Task<ActionResult<Course>> Create(CourseForCreate course)
        {
            var courseToCreate = new Course
            {
                Name = course.Name,
                Description = course.Description
            };

            var createdCourse = await _repos.CreateAsync(courseToCreate, course.TeacherId);

            if(createdCourse == null)
            {
                return BadRequest();
            }

            var courseForReturn = new Course
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
                Description = createdCourse.Description,
                Formula = createdCourse.Formula
            };

            return courseForReturn;
        }

        [HttpGet("get-teacher-courses/{id}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetTeacherCourses(int id)
        {
            var courses = await _repos.GetTeacherCourses(id);

            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        [HttpGet("get-student-courses/{id}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetStudentCourses(int id)
        {
            var courses = await _repos.GetStudentCourses(id);

            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        [HttpGet("get-all-courses")]  // для администратора
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _repos.GetAllCourses();

            if (courses == null) 
            {
                return NotFound();
            }

            return Ok(courses);
        }

        [HttpPut("update-course/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(course);
        }

        [HttpDelete("delete-course/{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound("Курс не найден");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
