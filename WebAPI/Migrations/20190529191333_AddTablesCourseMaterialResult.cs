using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddTablesCourseMaterialResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifact_Users_StudentId",
                table: "Artifact");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifact_Users_TeacherId",
                table: "Artifact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artifact",
                table: "Artifact");

            migrationBuilder.RenameTable(
                name: "Artifact",
                newName: "Artifacts");

            migrationBuilder.RenameIndex(
                name: "IX_Artifact_TeacherId",
                table: "Artifacts",
                newName: "IX_Artifacts_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Artifact_StudentId",
                table: "Artifacts",
                newName: "IX_Artifacts_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artifacts",
                table: "Artifacts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Formula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMaterials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SudentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    StudyYear = table.Column<DateTimeOffset>(nullable: false),
                    Grade = table.Column<float>(nullable: false),
                    Bonus = table.Column<float>(nullable: false),
                    TotalGrade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterials_CourseId",
                table: "CourseMaterials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CourseId",
                table: "Results",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_UserId",
                table: "TeacherCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Users_StudentId",
                table: "Artifacts",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Users_TeacherId",
                table: "Artifacts",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Users_StudentId",
                table: "Artifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Users_TeacherId",
                table: "Artifacts");

            migrationBuilder.DropTable(
                name: "CourseMaterials");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artifacts",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ads");

            migrationBuilder.RenameTable(
                name: "Artifacts",
                newName: "Artifact");

            migrationBuilder.RenameIndex(
                name: "IX_Artifacts_TeacherId",
                table: "Artifact",
                newName: "IX_Artifact_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Artifacts_StudentId",
                table: "Artifact",
                newName: "IX_Artifact_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artifact",
                table: "Artifact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artifact_Users_StudentId",
                table: "Artifact",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artifact_Users_TeacherId",
                table: "Artifact",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
