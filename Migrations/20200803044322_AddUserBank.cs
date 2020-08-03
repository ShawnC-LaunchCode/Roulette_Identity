using Microsoft.EntityFrameworkCore.Migrations;

namespace Roulette_Identity.Migrations
{
    public partial class AddUserBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bank",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank",
                table: "AspNetUsers");
        }
    }
}
