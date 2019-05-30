﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190529191333_AddTablesCourseMaterialResult")]
    partial class AddTablesCourseMaterialResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Data.Entities.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDate");

                    b.Property<string>("Header");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Artifact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("SendDate");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Artifacts");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Cluster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Group");

                    b.Property<string>("StudyFlow");

                    b.Property<string>("SubGroup");

                    b.HasKey("Id");

                    b.ToTable("Clusters");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Formula");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.CourseMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseMaterials");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Bonus");

                    b.Property<int>("CourseId");

                    b.Property<float>("Grade");

                    b.Property<DateTimeOffset>("StudyYear");

                    b.Property<int>("SudentId");

                    b.Property<string>("TotalGrade");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.TeacherCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("TeacherId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdNotify");

                    b.Property<string>("ArtifactNotify");

                    b.Property<int?>("ClusterId");

                    b.Property<string>("ConfirmEmail");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MessageNotify");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Patronymic");

                    b.Property<string>("ResultNotify");

                    b.Property<string>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("ClusterId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Ad", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.User", "User")
                        .WithMany("Ads")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Artifact", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.User", "Student")
                        .WithMany("StudentArtifacts")
                        .HasForeignKey("StudentId");

                    b.HasOne("WebAPI.Data.Entities.User", "Teacher")
                        .WithMany("TeacherArtifacts")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.CourseMaterial", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.Course", "Course")
                        .WithMany("CourseMaterials")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Result", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.Course", "Course")
                        .WithMany("Results")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Data.Entities.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.TeacherCourse", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.Course", "Course")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Data.Entities.User", "User")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.User", b =>
                {
                    b.HasOne("WebAPI.Data.Entities.Cluster", "Cluster")
                        .WithMany("Users")
                        .HasForeignKey("ClusterId");
                });
#pragma warning restore 612, 618
        }
    }
}
