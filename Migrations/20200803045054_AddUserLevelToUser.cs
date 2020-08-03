using Microsoft.EntityFrameworkCore.Migrations;

namespace Roulette_Identity.Migrations
{
    public partial class AddUserLevelToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserLevel",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "AspNetUsers");
        }
    }
}
