using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_role_employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d1b5c3-f2c6-48b1-9e8c-6b24d5aa3c50");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51830634-e133-4268-9dc4-2f24e2194adc", null, "Employee", "Employee" },
                   
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51830634-e133-4268-9dc4-2f24e2194adc");

          

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28d1b5c3-f2c6-48b1-9e8c-6b24d5aa3c50", null, "Admin", "Admin" });
        }
    }
}
