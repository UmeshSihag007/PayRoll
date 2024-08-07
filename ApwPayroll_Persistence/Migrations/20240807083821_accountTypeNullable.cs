using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class accountTypeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_RelationTypes_RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5ea4dc-bd49-450c-8c49-13a17f32dabd");

            migrationBuilder.AlterColumn<int>(
                name: "RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                schema: "PayRolls",
                table: "BankDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountBranch",
                schema: "PayRolls",
                table: "BankDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

             

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_RelationTypes_RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts",
                column: "RelationTypeId",
                principalSchema: "PayRolls",
                principalTable: "RelationTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_RelationTypes_RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be45d3bf-e750-452e-b3a7-4a9a3bb70e5a");

            migrationBuilder.AlterColumn<int>(
                name: "RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                schema: "PayRolls",
                table: "BankDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountBranch",
                schema: "PayRolls",
                table: "BankDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd5ea4dc-bd49-450c-8c49-13a17f32dabd", null, "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_RelationTypes_RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts",
                column: "RelationTypeId",
                principalSchema: "PayRolls",
                principalTable: "RelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
