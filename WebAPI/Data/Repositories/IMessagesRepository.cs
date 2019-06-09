using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Helpers;

namespace WebAPI.Data.Repositories
{
    public interface IMessagesRepository
    {
        Task<Message> Add(Message message);

        Task<Message> GetMessage(int id);

        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);

        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}
