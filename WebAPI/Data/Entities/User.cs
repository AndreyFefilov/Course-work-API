using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        public string ConfirmEmail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Role { get; set; }

        public string MessageNotify { get; set; }
        public string AdNotify { get; set; }
        public string ArtifactNotify { get; set; }
        public string ResultNotify { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string PhotoUrl { get; set; }

        public int? ClusterId { get; set; }
        public Cluster Cluster { get; set; }

        [InverseProperty("Student")]
        public List<Artifact> StudentArtifacts { get; set; }

        [InverseProperty("Teacher")]
        public List<Artifact> TeacherArtifacts { get; set; }

        public List<Ad> Ads { get; set; }
        public List<Result> Results { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
        public List<ExamGrade> ExamGrades { get; set; }

        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
    }
}
