using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CacheApp.Migrations
{
    public partial class AddUserIdToFirearmAndCaliber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Firearm",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Caliber",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Firearm");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Caliber");
        }
    }
}
