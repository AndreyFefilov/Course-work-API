using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Models.EnitiesDTO;

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

            return findedCourse;
        }

        public async Task<IEnumerable<CourseDTO>> GetStudentCourses(int id)
        {
            var courses = await _context.Courses
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Formula = c.Formula
                }).ToListAsync();

            var selectedCoursesIds = await _context.Results
                            .Where(t => t.StudentId == id && t.InArchive == "N")
                            .Select(x => x.CourseId).ToListAsync();

            return courses.Where(x => selectedCoursesIds.Contains(x.Id));
        }

        public async Task<IEnumerable<CourseDTO>> GetTeacherCourses(int id)
        {
            var courses = await _context.Courses
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Formula = c.Formula
                }).ToListAsync();

            var selectedCoursesIds = await _context.TeacherCourses
                .Where(t => t.TeacherId == id)
                .Select(x => x.CourseId).ToListAsync();

            return courses.Where(x => selectedCoursesIds.Contains(x.Id));
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
