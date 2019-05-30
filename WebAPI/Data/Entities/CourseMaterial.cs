using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class CourseMaterial
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
