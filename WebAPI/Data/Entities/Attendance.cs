using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User User { get; set; }

        public double ClassGrade { get; set; }
    }
}
