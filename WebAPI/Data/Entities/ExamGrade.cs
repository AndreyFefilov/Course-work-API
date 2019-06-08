using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class ExamGrade
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User User { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }
    }
}
