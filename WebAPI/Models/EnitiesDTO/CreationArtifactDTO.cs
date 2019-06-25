using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.EnitiesDTO
{
    public class CreationArtifactDTO
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public DateTime DateSend { get; set; }

        public CreationArtifactDTO()
        {
            DateSend = DateTime.Now;
        }
    }
}
