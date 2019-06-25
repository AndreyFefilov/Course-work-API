using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? DateSend { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ArtifactId { get; set; }
        public Artifact Artifact { get; set; }

        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
