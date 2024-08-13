using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_role_employee1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ee13843-7c50-4985-8d06-fbdf61a4ace4");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c7b835-970c-4dbb-86a3-d390c541f24a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    
                    { "46c7b835-970c-4dbb-86a3-d390c541f24a", null, "Employee", "Employee" }
                });
        }
    }
}
