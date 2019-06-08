using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<CourseMaterial>> GetCourseMaterials(int id);

        Task<CourseMaterial> CreateMaterial(CourseMaterial material);
    }
}
