using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Data.Repositories;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITeacherCoursesRepository _repos;

        public TeacherCoursesController(DataContext context, ITeacherCoursesRepository repos)
        {
            _context = context;
            _repos = repos;
        }

        [HttpPost("add-teacher")]
        public async Task<ActionResult<TeacherCourse>> AddTeacherCourse(TeacherCourse teacherCourse)
        {
            var createdTeacherCourse = await _repos.AddTeacher(teacherCourse);

            if (createdTeacherCourse == null)
            {
                return BadRequest();
            }

            return StatusCode(201);
        }

        [HttpDelete("delete-teacher-course")]
        public async Task<ActionResult<TeacherCourse>> DeleteTeacherCourse(TeacherCourseDTO teacherCourse)
        {
            var foundTeacherCourse = _context.TeacherCourses
                    .Where(t => t.TeacherId == teacherCourse.TeacherId && t.CourseId == teacherCourse.CourseId)
                    .FirstOrDefault();

            if (foundTeacherCourse == null)
            {
                return NotFound();
            }

            _context.TeacherCourses.Remove(foundTeacherCourse);
            await _context.SaveChangesAsync();

            return foundTeacherCourse;
        }

        private bool TeacherCourseExists(int id)
        {
            return _context.TeacherCourses.Any(e => e.Id == id);
        }
    }
}
