using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FixFKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Users_UserId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_UserId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "SudentId",
                table: "Results",
                newName: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_TeacherId",
                table: "Ads",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_TeacherId",
                table: "Ads",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_StudentId",
                table: "Results",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Users_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_TeacherId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_StudentId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Users_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_Results_StudentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Ads_TeacherId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Results",
                newName: "SudentId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TeacherCourses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Results",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ads",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_UserId",
                table: "TeacherCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Users_UserId",
                table: "TeacherCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
