using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DataContext _context;

        public MaterialRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CourseMaterial> CreateMaterial(CourseMaterial material)
        {
            await _context.CourseMaterials.AddAsync(material);
            await _context.SaveChangesAsync();

            var findedMaterial = await _context.CourseMaterials.FindAsync(material.Id);

            var materialToReturn = new CourseMaterial
            {
                Id = findedMaterial.Id,
                Name = findedMaterial.Name,
                Link = findedMaterial.Link,
                CourseId = findedMaterial.CourseId
            };

            return materialToReturn;
        }


        public async Task<IEnumerable<CourseMaterial>> GetCourseMaterials(int id)
        {
            return await _context.CourseMaterials
                .Where(c => c.CourseId == id)
                .ToListAsync();
        }
    }
}
