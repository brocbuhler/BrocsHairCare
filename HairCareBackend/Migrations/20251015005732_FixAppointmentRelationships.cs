using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairCareBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixAppointmentRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId1",
                table: "AppointmentServices",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServiceId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "ServiceId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_ServiceId1",
                table: "AppointmentServices",
                column: "ServiceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId1",
                table: "AppointmentServices",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId1",
                table: "AppointmentServices");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentServices_ServiceId1",
                table: "AppointmentServices");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "AppointmentServices");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServiceId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
