using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repos;

        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repos, IConfiguration config)
        {
            _repos = repos;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationStudent studentModel)
        {
            studentModel.Username = studentModel.Username.ToLower();


            if (await _repos.UserExists(studentModel.Username))
                return BadRequest("Такой логин уже занят");

            if (await _repos.EmailExists(studentModel.Email))
                return BadRequest("Такая почта уже используется");

            var userToCreate = new User
            {
                Username = studentModel.Username,
                Email = studentModel.Email,
                ConfirmEmail = "N",
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Patronymic = studentModel.Patronymic,
                Role = "Студент",
                MessageNotify = "Y",
                AdNotify = "Y",
                ArtifactNotify = "Y",
                ResultNotify = "Y",
                ClusterId = studentModel.ClusterId
            };

            var createdUser = await _repos.Register(userToCreate, studentModel.Password);

            return StatusCode(201);
        }

        [HttpPost("register-teacher")]
        public async Task<IActionResult> RegisterTeacher(RegistrationTeacher teacher)
        {
            teacher.Username = teacher.Username.ToLower();

            if (await _repos.UserExists(teacher.Username))
                return BadRequest("Такой логин уже занят");

            if (await _repos.EmailExists(teacher.Email))
                return BadRequest("Такая почта уже используется");

            var userToCreate = new User
            {
                Username = teacher.Username,
                Email = teacher.Email,
                ConfirmEmail = "N",
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Patronymic = teacher.Patronymic,
                Role = "Преподаватель",
                MessageNotify = "Y",
                AdNotify = "Y",
                ArtifactNotify = "Y",
                ResultNotify = "N"
            };

            var createdUser = await _repos.Register(userToCreate, teacher.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogin userForLogin)
        {
            var userFromRepos = await _repos.Login(userForLogin.Username, userForLogin.Password);

            if (userFromRepos == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepos.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepos.Username)
            };

            var key = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
