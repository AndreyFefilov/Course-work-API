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
using WebAPI.Helpers;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMessagesRepository _repos;
        private readonly IUsersRepository _userRepos;
        private readonly IMapper _mapper;

        public MessagesController(DataContext context,
                                  IMessagesRepository repos,
                                  IUsersRepository userRepos,
                                  IMapper mapper)
        {
            _context = context;
            _repos = repos;
            _userRepos = userRepos;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessage(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var messageFromRepos = await _repos.GetMessage(id);

            if (messageFromRepos == null)
                return NotFound("Сообщение не найдено");

            return Ok(messageFromRepos);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesForUser(int userId,
            [FromQuery]MessageParams messageParams)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            messageParams.UserId = userId;

            var messagesFromRepos = await _repos.GetMessagesForUser(messageParams);

            var messages = _mapper.Map<IEnumerable<MessageToReturnDTO>>(messagesFromRepos);

            Response.AddPagination(
                messagesFromRepos.CurrentPage,
                messagesFromRepos.PageSize,
                messagesFromRepos.TotalCount,
                messagesFromRepos.TotalPages);

            return Ok(messages);
        }

        [HttpGet("thread/{recipientId}")]
        public async Task<IActionResult> GetMessageThread(int userId, int recipientId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var messagesFromRepos = await _repos.GetMessageThread(userId, recipientId);

            var messageThread = _mapper.Map<IEnumerable<MessageToReturnDTO>>(messagesFromRepos);

            return Ok(messageThread);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId, CreationMessageDTO creationMessage)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            creationMessage.SenderId = userId;

            var recipient = await _userRepos.GetUser(creationMessage.RecipientId);

            if (recipient == null)
                return BadRequest("Пользователь не найден");

            var message = _mapper.Map<Message>(creationMessage);

            await _repos.Add(message);

            var messageToReturn = _mapper.Map<CreationMessageDTO>(message);

            return CreatedAtRoute("GetMessage", new { id = message.Id }, messageToReturn);
        }
    }
}
