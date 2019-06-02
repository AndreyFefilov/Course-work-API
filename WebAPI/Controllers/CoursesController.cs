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

        public CoursesController(ICoursesRepository repos)
        {
            _repos = repos;
        }

        [HttpPost("create-course")]
        public async Task<IActionResult> Create(CourseForCreate course)
        {
            var courseToCreate = new Course
            {
                Name = course.Name,
                Description = course.Description
            };

            int id = course.TeacherId;

            var createdCourse = await _repos.CreateAsync(courseToCreate, id);

            return StatusCode(201);
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
    }
}
