using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class holidayRuleNullAlbles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidatTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles");

         

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

         

            migrationBuilder.AddForeignKey(
                name: "FK_HolidatTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "BranchId",
                principalSchema: "PayRolls",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidatTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles");

        

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_HolidatTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "BranchId",
                principalSchema: "PayRolls",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
