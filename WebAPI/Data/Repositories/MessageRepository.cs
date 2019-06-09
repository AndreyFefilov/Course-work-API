using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;
using WebAPI.Helpers;

namespace WebAPI.Data.Repositories
{
    public class MessageRepository : IMessagesRepository
    {
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Message> Add(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages
                .Include(u => u.Sender)
                .Include(u => u.Recipient)
                .AsQueryable();

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsRead == false);
                    break;
            }

            messages = messages.OrderBy(d => d.DateSend);

            return await PagedList<Message>.CreateAsync(
                messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages
                .Include(u => u.Sender)
                .Include(u => u.Recipient)
                .Where(m => (m.RecipientId == userId && m.SenderId == recipientId)
                    || (m.RecipientId == recipientId && m.SenderId == userId))
                .OrderBy(m => m.DateSend)
                .ToListAsync();

            return messages;
        }
   
    }
}
