using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class TeacherCourse
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string Main { get; set; }
    }
}
