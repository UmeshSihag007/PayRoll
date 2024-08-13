using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changethedataTypeofBanAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d1b5c3-f2c6-48b1-9e8c-6b24d5aa3c50");

            migrationBuilder.AlterColumn<long>(
                name: "BanAccountId",
                schema: "PayRolls",
                table: "BankDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d190116-3431-45e5-b66b-cc006f7ca61c", null, "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d190116-3431-45e5-b66b-cc006f7ca61c");

            migrationBuilder.AlterColumn<int>(
                name: "BanAccountId",
                schema: "PayRolls",
                table: "BankDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28d1b5c3-f2c6-48b1-9e8c-6b24d5aa3c50", null, "Admin", "Admin" });
        }
    }
}
