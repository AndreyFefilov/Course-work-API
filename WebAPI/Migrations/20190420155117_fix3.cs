using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Users_StudentId",
                table: "Artifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Users_TeacherId",
                table: "Artifacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artifacts",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "StudentUserId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "TeacherUserId",
                table: "Artifacts");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "StudentUserId",
                table: "Artifacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserId",
                table: "Artifacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artifacts",
                table: "Artifacts",
                column: "Id");

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
    }
}
