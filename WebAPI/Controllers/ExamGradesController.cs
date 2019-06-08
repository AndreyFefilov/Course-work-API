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
    public class ExamGradesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExamGradesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ExamGrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamGrade>>> GetExamGrades()
        {
            return await _context.ExamGrades.ToListAsync();
        }

        // GET: api/ExamGrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamGrade>> GetExamGrade(int id)
        {
            var examGrade = await _context.ExamGrades.FindAsync(id);

            if (examGrade == null)
            {
                return NotFound();
            }

            return examGrade;
        }

        // PUT: api/ExamGrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamGrade(int id, ExamGrade examGrade)
        {
            if (id != examGrade.Id)
            {
                return BadRequest();
            }

            _context.Entry(examGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamGradeExists(id))
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

        // POST: api/ExamGrades
        [HttpPost]
        public async Task<ActionResult<ExamGrade>> PostExamGrade(ExamGrade examGrade)
        {
            _context.ExamGrades.Add(examGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamGrade", new { id = examGrade.Id }, examGrade);
        }

        // DELETE: api/ExamGrades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExamGrade>> DeleteExamGrade(int id)
        {
            var examGrade = await _context.ExamGrades.FindAsync(id);
            if (examGrade == null)
            {
                return NotFound();
            }

            _context.ExamGrades.Remove(examGrade);
            await _context.SaveChangesAsync();

            return examGrade;
        }

        private bool ExamGradeExists(int id)
        {
            return _context.ExamGrades.Any(e => e.Id == id);
        }
    }
}
