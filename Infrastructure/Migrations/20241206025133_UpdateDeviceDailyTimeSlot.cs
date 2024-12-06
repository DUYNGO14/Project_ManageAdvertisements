using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeviceDailyTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDailyTimeSlot_DeviceDailyAvailability_DeviceDailyAvailabilityId",
                table: "DeviceDailyTimeSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDailyTimeSlot_TimeSlots_TimeSlotId",
                table: "DeviceDailyTimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceDailyTimeSlot",
                table: "DeviceDailyTimeSlot");

            migrationBuilder.RenameTable(
                name: "DeviceDailyTimeSlot",
                newName: "DeviceDailyTimeSlots");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceDailyTimeSlot_TimeSlotId",
                table: "DeviceDailyTimeSlots",
                newName: "IX_DeviceDailyTimeSlots_TimeSlotId");

            migrationBuilder.AddColumn<double>(
                name: "TotalAvailableMinutes",
                table: "DeviceDailyTimeSlots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceDailyTimeSlots",
                table: "DeviceDailyTimeSlots",
                columns: new[] { "DeviceDailyAvailabilityId", "TimeSlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDailyTimeSlots_DeviceDailyAvailability_DeviceDailyAvailabilityId",
                table: "DeviceDailyTimeSlots",
                column: "DeviceDailyAvailabilityId",
                principalTable: "DeviceDailyAvailability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDailyTimeSlots_TimeSlots_TimeSlotId",
                table: "DeviceDailyTimeSlots",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDailyTimeSlots_DeviceDailyAvailability_DeviceDailyAvailabilityId",
                table: "DeviceDailyTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDailyTimeSlots_TimeSlots_TimeSlotId",
                table: "DeviceDailyTimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceDailyTimeSlots",
                table: "DeviceDailyTimeSlots");

            migrationBuilder.DropColumn(
                name: "TotalAvailableMinutes",
                table: "DeviceDailyTimeSlots");

            migrationBuilder.RenameTable(
                name: "DeviceDailyTimeSlots",
                newName: "DeviceDailyTimeSlot");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceDailyTimeSlots_TimeSlotId",
                table: "DeviceDailyTimeSlot",
                newName: "IX_DeviceDailyTimeSlot_TimeSlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceDailyTimeSlot",
                table: "DeviceDailyTimeSlot",
                columns: new[] { "DeviceDailyAvailabilityId", "TimeSlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDailyTimeSlot_DeviceDailyAvailability_DeviceDailyAvailabilityId",
                table: "DeviceDailyTimeSlot",
                column: "DeviceDailyAvailabilityId",
                principalTable: "DeviceDailyAvailability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDailyTimeSlot_TimeSlots_TimeSlotId",
                table: "DeviceDailyTimeSlot",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
