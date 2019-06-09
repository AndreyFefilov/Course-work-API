using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.EnitiesDTO
{
    public class MessageToReturnDTO
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhotoUrl { get; set; }

        public int RecipientId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhotoUrl { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime? DateSend { get; set; }
    }
}
