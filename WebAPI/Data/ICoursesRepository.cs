using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public interface ICoursesRepository
    {
        Task<Course> CreateAsync(Course course, int id);
    }
}
