using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<CourseMaterial> CourseMaterials { get; set; }
        public DbSet<ExamGrade> ExamGrades { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
               .HasOne(u => u.Recipient)
               .WithMany(m => m.MessagesReceived)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
