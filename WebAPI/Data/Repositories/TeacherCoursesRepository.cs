using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Repositories
{
    public class TeacherCoursesRepository : ITeacherCoursesRepository
    {
        private readonly DataContext _context;

        public TeacherCoursesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TeacherCourse> AddTeacher(TeacherCourse teacherCourse)
        {
            teacherCourse.Main = "N";

            await _context.TeacherCourses.AddAsync(teacherCourse);
            await _context.SaveChangesAsync();

            return teacherCourse;
        }
    }
}
