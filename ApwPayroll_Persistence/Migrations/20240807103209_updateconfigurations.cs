using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayTypeRuleLocation_HolidatTypeRoles_HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation");

            migrationBuilder.DropIndex(
                name: "IX_HolidayTypeRuleLocation_HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation");

   

            migrationBuilder.DropColumn(
                name: "HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
   

            migrationBuilder.AddColumn<int>(
                name: "HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation",
                type: "int",
                nullable: true);



            migrationBuilder.CreateIndex(
                name: "IX_HolidayTypeRuleLocation_HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation",
                column: "HolidayTypeRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayTypeRuleLocation_HolidatTypeRoles_HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation",
                column: "HolidayTypeRuleId",
                principalSchema: "PayRolls",
                principalTable: "HolidatTypeRoles",
                principalColumn: "Id");
        }
    }
}
