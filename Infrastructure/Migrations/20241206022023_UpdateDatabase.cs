using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceDailyAvailability",
                table: "DeviceDailyAvailability");

            migrationBuilder.AlterColumn<double>(
                name: "TotalAvailableMinutes",
                table: "DeviceDailyAvailability",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeviceDailyAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceDailyAvailability",
                table: "DeviceDailyAvailability",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeviceDailyTimeSlot",
                columns: table => new
                {
                    DeviceDailyAvailabilityId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDailyTimeSlot", x => new { x.DeviceDailyAvailabilityId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_DeviceDailyTimeSlot_DeviceDailyAvailability_DeviceDailyAvailabilityId",
                        column: x => x.DeviceDailyAvailabilityId,
                        principalTable: "DeviceDailyAvailability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDailyTimeSlot_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDailyAvailability_DeviceID",
                table: "DeviceDailyAvailability",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDailyTimeSlot_TimeSlotId",
                table: "DeviceDailyTimeSlot",
                column: "TimeSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceDailyTimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceDailyAvailability",
                table: "DeviceDailyAvailability");

            migrationBuilder.DropIndex(
                name: "IX_DeviceDailyAvailability_DeviceID",
                table: "DeviceDailyAvailability");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeviceDailyAvailability");

            migrationBuilder.AlterColumn<int>(
                name: "TotalAvailableMinutes",
                table: "DeviceDailyAvailability",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceDailyAvailability",
                table: "DeviceDailyAvailability",
                columns: new[] { "DeviceID", "DateTime" });
        }
    }
}
