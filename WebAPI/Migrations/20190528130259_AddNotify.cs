using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddNotify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdNotify",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtifactNotify",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageNotify",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultNotify",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdNotify",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ArtifactNotify",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConfirmEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MessageNotify",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResultNotify",
                table: "Users");
        }
    }
}
