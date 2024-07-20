using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addColoumn_EmployeeDocumentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90cc5ac5-8997-408f-a1d4-be68c2c720cc");

            migrationBuilder.AddColumn<string>(
                name: "Heading",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCodeShow",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6f7aca7-ad40-4593-bc48-5a7e51bb0cc5", null, "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f7aca7-ad40-4593-bc48-5a7e51bb0cc5");

            migrationBuilder.DropColumn(
                name: "Heading",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "IsCodeShow",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90cc5ac5-8997-408f-a1d4-be68c2c720cc", null, "Admin", "Admin" });
        }
    }
}
