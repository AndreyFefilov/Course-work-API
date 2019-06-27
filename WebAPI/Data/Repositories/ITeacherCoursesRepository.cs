using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Repositories
{
    public interface ITeacherCoursesRepository
    {
        Task<TeacherCourse> AddTeacher(TeacherCourse teacherCourse);
    }
}
