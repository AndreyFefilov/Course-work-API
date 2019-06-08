using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Mandatory { get; set; }

        public double MinValue  { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        List<ExamGrade> ExamGrades { get; set; }
    }
}
