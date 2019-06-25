using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Formula { get; set; }

        public List<Result> Results { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
        public List<CourseMaterial> CourseMaterials { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Class> Classes { get; set; }
    }
}
