using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Cluster
    {
        public int Id { get; set; }

        public string StudyFlow { get; set; }

        public string Group { get; set; }

        public string SubGroup { get; set; }

        public List<User> Users { get; set; }
    }
}
