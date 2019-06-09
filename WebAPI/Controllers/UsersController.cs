using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Data.Repositories;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repos;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UsersController(IUsersRepository repos, DataContext context,
                                IMapper mapper)
        {
            _repos = repos;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _repos.GetAllUsers();

            var usersToReturn = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("get-user/{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _repos.GetUser(id);

            var userToReturn = _mapper.Map<UserDTO>(user);

            return Ok(userToReturn);
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
                return NotFound();
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
