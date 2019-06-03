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

            return material;
        }


        public async Task<IEnumerable<CourseMaterial>> GetCourseMaterials(int id)
        {
            return await _context.CourseMaterials
                .Where(c => c.CourseId == id)
                .ToListAsync();
        }
    }
}
