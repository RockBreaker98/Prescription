using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.Migrations
{
    /// <inheritdoc />
    public partial class AddSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Prescriptions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "PrescriptionId",
                keyValue: 1,
                column: "Slug",
                value: "");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "PrescriptionId",
                keyValue: 2,
                column: "Slug",
                value: "");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "PrescriptionId",
                keyValue: 3,
                column: "Slug",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Prescriptions");
        }
    }
}
