using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CacheApp.Migrations
{
    public partial class CreateFirearmAndCaliberSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caliber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caliber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firearm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CaliberId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturerImporter = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DateAcquired = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PurchaseLocation = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    DateSold = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SoldTransferredTo = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firearm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firearm_Caliber_CaliberId",
                        column: x => x.CaliberId,
                        principalTable: "Caliber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firearm_CaliberId",
                table: "Firearm",
                column: "CaliberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firearm");

            migrationBuilder.DropTable(
                name: "Caliber");
        }
    }
}
