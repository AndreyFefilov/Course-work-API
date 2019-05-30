using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class ClusterIdIsNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clusters_ClusterId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ClusterId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clusters_ClusterId",
                table: "Users",
                column: "ClusterId",
                principalTable: "Clusters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clusters_ClusterId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ClusterId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clusters_ClusterId",
                table: "Users",
                column: "ClusterId",
                principalTable: "Clusters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
