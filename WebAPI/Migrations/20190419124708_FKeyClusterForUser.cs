using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FKeyClusterForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClusterId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClusterId",
                table: "Users",
                column: "ClusterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clusters_ClusterId",
                table: "Users",
                column: "ClusterId",
                principalTable: "Clusters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clusters_ClusterId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClusterId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClusterId",
                table: "Users");
        }
    }
}
