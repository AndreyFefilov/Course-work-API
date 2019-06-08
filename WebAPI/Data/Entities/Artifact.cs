using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Artifact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SendDate  { get; set; }

        [NotMapped]
        public User Student { get; set; }

        [NotMapped]
        public User Teacher { get; set; }

    }
}
