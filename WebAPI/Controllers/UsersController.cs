using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Data.Repositories;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repos;
        private readonly DataContext _context;

        public UsersController(IUsersRepository repos, DataContext context)
        {
            _repos = repos;
            _context = context;
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _repos.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("get-user/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repos.GetUser(id);

            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            return user;
        }

        [HttpGet("get-students/{id}")]
        public async Task<ActionResult<User>> GetStudents(int id)
        {
            var students = await _repos.GetStudents(id);

            if (students == null)
            {
                return NotFound("На этой дисциплине нет студентов");
            }

            return Ok(students);
        }

        [HttpGet("get-teachers/{id}")]
        public async Task<ActionResult<User>> GetTeachers(int id)
        {
            var teachers = await _repos.GetTeachers(id);

            if (teachers == null)
            {
                return NotFound("На этой дисциплине нет студентов");
            }

            return Ok(teachers);
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
