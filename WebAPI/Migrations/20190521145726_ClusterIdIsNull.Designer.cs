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
    [Migration("20190521145726_ClusterIdIsNull")]
    partial class ClusterIdIsNull
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

                    b.Property<string>("Text");

                    b.HasKey("Id");

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

                    b.ToTable("Artifact");
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

            modelBuilder.Entity("WebAPI.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClusterId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Patronymic");

                    b.Property<string>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("ClusterId");

                    b.ToTable("Users");
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
