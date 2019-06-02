using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Result
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string StudyYear { get; set; }

        public double? Grade { get; set; }

        public double? Bonus { get; set; }

        public string TotalGrade { get; set; }

        public string InArchive { get; set; }
    }
}
