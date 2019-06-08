using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMaterialsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMaterialRepository _repos;

        public CourseMaterialsController(DataContext context, IMaterialRepository repos)
        {
            _context = context;
            _repos = repos;
        }

        [HttpGet("get-materials/{id}")]
        public async Task<ActionResult<CourseMaterial>> GetCourseMaterials(int id)
        {
            var materials = await _repos.GetCourseMaterials(id);

            if (materials == null)
            {
                return NotFound();
            }

            return Ok(materials);
        }

        [HttpPost("create-material")]
        public async Task<ActionResult<CourseMaterial>> CreateMaterial(MaterialForCreate courseMaterial)
        {
            var material = new CourseMaterial
            {
                Name = courseMaterial.Name,
                Link = courseMaterial.Link,
                CourseId = courseMaterial.CourseId
            };
            
            var createdMaterial = await _repos.CreateMaterial(material);

            if (createdMaterial == null)
            {
                return BadRequest("Материал не создан");
            }

            return createdMaterial;
        }

        [HttpDelete("delete-material/{id}")]
        public async Task<ActionResult> DeleteCourseMaterial(int id)
        {
            var courseMaterial = await _context.CourseMaterials.FindAsync(id);
            if (courseMaterial == null)
            {
                return NotFound("Такого материала нет");
            }

            _context.CourseMaterials.Remove(courseMaterial);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update-material/{id}")]
        public async Task<IActionResult> UpdateCourseMaterial(int id, CourseMaterial courseMaterial)
        {
            if (id != courseMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseMaterialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(courseMaterial);
        }

        private bool CourseMaterialExists(int id)
        {
            return _context.CourseMaterials.Any(e => e.Id == id);
        }
    }
}
