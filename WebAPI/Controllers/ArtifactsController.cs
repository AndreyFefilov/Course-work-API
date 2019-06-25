using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class ArtifactsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IArtifactRepository _repos;
        private readonly IUsersRepository _userRepos;
        private readonly IMapper _mapper;

        public ArtifactsController(DataContext context,
                                  IArtifactRepository repos,
                                  IUsersRepository userRepos,
                                  IMapper mapper)
        {
            _context = context;
            _repos = repos;
            _userRepos = userRepos;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetArtifact")]
        public async Task<IActionResult> GetArtifact(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var artifactFromRepos = await _repos.GetArtifact(id);

            if (artifactFromRepos == null)
                return NotFound("Артефакт не найден");

            return Ok(artifactFromRepos);
        }


        [HttpGet("thread/{recipientId}")]
        public async Task<IActionResult> GetArtifactThread(int userId, int recipientId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var artifactsFromRepos = await _repos.GetArtifactThread(userId, recipientId);

            var artifactThread = _mapper.Map<IEnumerable<ArtifactToReturnDTO>>(artifactsFromRepos);

            return Ok(artifactThread);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtifact(int userId, CreationArtifactDTO creationArtifact)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            creationArtifact.StudentId = userId;

            var teacher = await _userRepos.GetUser(creationArtifact.TeacherId);

            if (teacher == null)
                return BadRequest("Преподаватель не найден");

            var artifact = _mapper.Map<Artifact>(creationArtifact);

            await _repos.AddArtifact(artifact);

            var artifactToReturn = _mapper.Map<CreationArtifactDTO>(artifact);

            return CreatedAtRoute("GetArtifact", new { id = artifact.Id }, artifactToReturn);
        }
    }
}
