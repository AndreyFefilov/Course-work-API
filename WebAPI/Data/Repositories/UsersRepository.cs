using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Data.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents(int courseId)
        {
            var students = await _context.Users
                            .Include(x => x.Cluster)
                            .Select(s => new StudentDTO
                            {
                                Id = s.Id,
                                Email = s.Email,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                Patronymic = s.Patronymic,
                                PhotoUrl = s.PhotoUrl,
                                Group = s.Cluster.Group,
                                SubGroup = s.Cluster.SubGroup
                            })
                            .OrderBy(a => a.FirstName)
                            .ToListAsync();

            var selectedStudentsIds = await _context.Results
                            .Where(t => t.CourseId == courseId && t.InArchive == "N")
                            .Select(x => x.StudentId).ToListAsync();

            return students.Where(x => selectedStudentsIds.Contains(x.Id));
        }

        public async Task<IEnumerable<TeacherDTO>> GetTeachers(int courseId)
        {
            return await (from u in _context.Users
                    join t in _context.TeacherCourses
                    on u.Id equals t.TeacherId
                    where t.CourseId == courseId
                    orderby u.FirstName
                    select new TeacherDTO
                    {
                        Id = u.Id,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Patronymic = u.Patronymic,
                        PhotoUrl = u.PhotoUrl,
                        Main = t.Main
                     })
                     .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

    }
}
