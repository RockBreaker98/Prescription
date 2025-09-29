using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prescription.Migrations
{
    /// <inheritdoc />
    public partial class Prescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicationName = table.Column<string>(type: "TEXT", nullable: false),
                    FillStatus = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "PrescriptionId", "Cost", "FillStatus", "MedicationName", "RequestTime" },
                values: new object[,]
                {
                    { 1, 12.99, "New", "Amoxicillin", new DateTime(2025, 9, 27, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 8.4900000000000002, "Filled", "Ibuprofen", new DateTime(2025, 9, 24, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 15.75, "Pending", "Lisinopril", new DateTime(2025, 9, 28, 10, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
