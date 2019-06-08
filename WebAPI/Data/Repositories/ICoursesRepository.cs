using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Data
{
    public interface ICoursesRepository
    {
        Task<Course> CreateAsync(Course course, int id);

        Task<IEnumerable<CourseDTO>> GetTeacherCourses(int id);

        Task<IEnumerable<CourseDTO>> GetStudentCourses(int id);
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
