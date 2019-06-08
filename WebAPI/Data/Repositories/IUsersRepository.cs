using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Data.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUser(int id);

        Task<IEnumerable<StudentDTO>> GetStudents(int courseId);

        Task<IEnumerable<TeacherDTO>> GetTeachers(int courseId);
    }
}
