using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addIsDocumentRequired_employeeDocumentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42cafe42-d21f-48b6-bd1d-2034b0402330");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5e1cda7-479d-43b0-a62f-51f087cc4d75");

            migrationBuilder.AddColumn<bool>(
                name: "IsCodeRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDocumentRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7160d13d-c9d1-477b-b324-afb8061885b7", null, "Admin", "Admin" },
                    { "e9a7a55b-a0c4-4969-b1d4-7bbcf5f120e6", null, "Employee", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7160d13d-c9d1-477b-b324-afb8061885b7");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9a7a55b-a0c4-4969-b1d4-7bbcf5f120e6");

            migrationBuilder.DropColumn(
                name: "IsCodeRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "IsDocumentRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42cafe42-d21f-48b6-bd1d-2034b0402330", null, "Employee", "Employee" },
                    { "b5e1cda7-479d-43b0-a62f-51f087cc4d75", null, "Admin", "Admin" }
                });
        }
    }
}
