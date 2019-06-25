using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime DateAndTime { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ClusterId { get; set; }
        public Cluster Cluster { get; set; }

        public List<Attendance> Attendances { get; set; }
    }
}
