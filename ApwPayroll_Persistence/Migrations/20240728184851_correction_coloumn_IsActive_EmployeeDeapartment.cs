using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class correction_coloumn_IsActive_EmployeeDeapartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08b7fd7-899f-455b-a96a-32abe394bcff");

            migrationBuilder.RenameColumn(
                name: "IActive",
                schema: "PayRolls",
                table: "EmployeeDepartments",
                newName: "IsActive");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28d1b5c3-f2c6-48b1-9e8c-6b24d5aa3c50", null, "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d1b5c3-f2c6-48b1-9e8c-6b24d5aa3c50");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "PayRolls",
                table: "EmployeeDepartments",
                newName: "IActive");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d08b7fd7-899f-455b-a96a-32abe394bcff", null, "Admin", "Admin" });
        }
    }
}
