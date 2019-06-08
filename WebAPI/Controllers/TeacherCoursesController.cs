using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly DataContext _context;

        public TeacherCoursesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TeacherCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherCourse>>> GetTeacherCourses()
        {
            return await _context.TeacherCourses.ToListAsync();
        }

        // GET: api/TeacherCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherCourse>> GetTeacherCourse(int id)
        {
            var teacherCourse = await _context.TeacherCourses.FindAsync(id);

            if (teacherCourse == null)
            {
                return NotFound();
            }

            return teacherCourse;
        }

        // PUT: api/TeacherCourses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherCourse(int id, TeacherCourse teacherCourse)
        {
            if (id != teacherCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeacherCourses
        [HttpPost]
        public async Task<ActionResult<TeacherCourse>> PostTeacherCourse(TeacherCourse teacherCourse)
        {
            _context.TeacherCourses.Add(teacherCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherCourse", new { id = teacherCourse.Id }, teacherCourse);
        }

        // DELETE: api/TeacherCourses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherCourse>> DeleteTeacherCourse(int id)
        {
            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            _context.TeacherCourses.Remove(teacherCourse);
            await _context.SaveChangesAsync();

            return teacherCourse;
        }

        private bool TeacherCourseExists(int id)
        {
            return _context.TeacherCourses.Any(e => e.Id == id);
        }
    }
}
