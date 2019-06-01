using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class CoursesRepository: ICoursesRepository
    {
        private readonly DataContext _context;

        public CoursesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course course, int id)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            var findedCourse = await _context.Courses.FindAsync(course.Id);
            
            var teacherCourse = new TeacherCourse
            {
                CourseId = findedCourse.Id,
                TeacherId = id,
                Main = "Y"
            };

            await _context.TeacherCourses.AddAsync(teacherCourse);
            await _context.SaveChangesAsync();

            return course;
        }
    }
}
