using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bankdetail_BankRefress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd939fbd-4728-4c1f-a6e4-f436751b4466");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                schema: "PayRolls",
                table: "BankDetails",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5532835-9d2f-4d7a-9bc0-59d03d22814b", null, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_BankId",
                schema: "PayRolls",
                table: "BankDetails",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_Banks_BankId",
                schema: "PayRolls",
                table: "BankDetails",
                column: "BankId",
                principalSchema: "PayRolls",
                principalTable: "Banks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDetails_Banks_BankId",
                schema: "PayRolls",
                table: "BankDetails");

            migrationBuilder.DropIndex(
                name: "IX_BankDetails_BankId",
                schema: "PayRolls",
                table: "BankDetails");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5532835-9d2f-4d7a-9bc0-59d03d22814b");

            migrationBuilder.DropColumn(
                name: "BankId",
                schema: "PayRolls",
                table: "BankDetails");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd939fbd-4728-4c1f-a6e4-f436751b4466", null, "Admin", "Admin" });
        }
    }
}
