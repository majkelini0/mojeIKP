using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mojeIKP.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseDataInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "tomaszewguru@gmail.com", "Michal", "Tomaszewski" },
                    { 2, "jaroslawpolskezbaw@gmail.com", "Jaroslaw", "Kaczynski" },
                    { 3, "dudawaswyduda@gmail.com", "Andrzej", "Duda" },
                    { 4, "germanislove@gmail.com", "Donald", "German" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "lek przeciwbolowy", "Paracetamol", "tabletki" },
                    { 2, "lek przeciwzapalny", "Ibuprofen MAX", "tabletki" },
                    { 3, "na gardlowe stany zapalne", "Tamtum Verde", "aerozol" },
                    { 4, "porost islandzki lagodzacy podraznione gardlo", "Isla", "pastylki do ssania" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1979, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Rzezucha" },
                    { 2, new DateTime(1921, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Pawel" },
                    { 3, new DateTime(1969, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grazyna", "Komuchuwna" },
                    { 4, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julia", "Przysrebska" },
                    { 5, new DateTime(1975, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacek", "Kusrski" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7249), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7300), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7304), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7308), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2024, 6, 13, 1, 19, 30, 156, DateTimeKind.Local).AddTicks(7311), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "po jednej tabletce 3 razy dziennie", 1 },
                    { 1, 2, "po jednej tabletce 3 razy dziennie", 1 },
                    { 2, 2, "po jednej tabletce 3 razy dziennie", 1 },
                    { 2, 5, "brac kiedy boli glowa", 2 },
                    { 3, 1, "ile wlezie do gardla", 1 },
                    { 3, 3, "cmukac umiarkowanie", 1 },
                    { 3, 4, "cmukac do woli", 2 },
                    { 4, 1, "cmukac do woli", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 5);
        }
    }
}
