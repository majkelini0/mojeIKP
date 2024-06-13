using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mojeIKP.Migrations
{
    /// <inheritdoc />
    public partial class stringemptytonull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 13, 3, 28, 9, 146, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 13, 3, 28, 9, 146, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 13, 3, 28, 9, 146, DateTimeKind.Local).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 13, 3, 28, 9, 146, DateTimeKind.Local).AddTicks(3229));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 13, 3, 28, 9, 146, DateTimeKind.Local).AddTicks(3232));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7311));
        }
    }
}
