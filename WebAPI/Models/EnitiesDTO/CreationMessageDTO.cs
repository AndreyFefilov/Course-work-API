using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.EnitiesDTO
{
    public class CreationMessageDTO
    {
        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public DateTime DateSend { get; set; }

        public string Content { get; set; }

        public CreationMessageDTO()
        {
            DateSend = DateTime.Now;
        }
    }
}
