using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRerence_LocationWith_EmployeeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5532835-9d2f-4d7a-9bc0-59d03d22814b");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0d25dba-97e1-4809-b163-80649bf46e04", null, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_LocationId",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddresses_Location_LocationId",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                column: "LocationId",
                principalSchema: "PayRolls",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddresses_Location_LocationId",
                schema: "PayRolls",
                table: "EmployeeAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAddresses_LocationId",
                schema: "PayRolls",
                table: "EmployeeAddresses");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0d25dba-97e1-4809-b163-80649bf46e04");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "PayRolls",
                table: "EmployeeAddresses");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5532835-9d2f-4d7a-9bc0-59d03d22814b", null, "Admin", "Admin" });
        }
    }
}
