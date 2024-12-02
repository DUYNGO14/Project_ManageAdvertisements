using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceDailyAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceDailyAvailability",
                columns: table => new
                {
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    TotalAvailableMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDailyAvailability", x => new { x.DeviceID, x.DateTime });
                    table.ForeignKey(
                        name: "FK_DeviceDailyAvailability_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceDailyAvailability");
        }
    }
}
