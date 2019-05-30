using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class PFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Artifacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentUserId",
                table: "Artifacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Artifacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserId",
                table: "Artifacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_StudentId",
                table: "Artifacts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_TeacherId",
                table: "Artifacts",
                column: "TeacherId");

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
                name: "FK_Artifacts_Users_StudentId",
                table: "Artifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Users_TeacherId",
                table: "Artifacts");

            migrationBuilder.DropIndex(
                name: "IX_Artifacts_StudentId",
                table: "Artifacts");

            migrationBuilder.DropIndex(
                name: "IX_Artifacts_TeacherId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "StudentUserId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "TeacherUserId",
                table: "Artifacts");
        }
    }
}
