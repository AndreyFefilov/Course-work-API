using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.EnitiesDTO
{
    public class ArtifactToReturnDTO
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public string StudentPhotoUrl { get; set; }

        public int TeacherId { get; set; }
        public string TeacherPhotoUrl { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime? DateSend { get; set; }
    }
}
