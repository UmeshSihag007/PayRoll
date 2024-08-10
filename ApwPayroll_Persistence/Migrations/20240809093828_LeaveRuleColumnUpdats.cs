using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LeaveRuleColumnUpdats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypeRoles_Designation_DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypeRoles_LeaveTypes_LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles");

           

            migrationBuilder.AlterColumn<int>(
                name: "LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

       
            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "BranchId",
                principalSchema: "PayRolls",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypeRoles_Designation_DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "DesignationId",
                principalSchema: "PayRolls",
                principalTable: "Designation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypeRoles_LeaveTypes_LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "LeaveTypeId",
                principalSchema: "PayRolls",
                principalTable: "LeaveTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypeRoles_Designation_DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypeRoles_LeaveTypes_LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles");


            migrationBuilder.AlterColumn<int>(
                name: "LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

       
            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypeRoles_Branches_BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "BranchId",
                principalSchema: "PayRolls",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypeRoles_Designation_DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "DesignationId",
                principalSchema: "PayRolls",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypeRoles_LeaveTypes_LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "LeaveTypeId",
                principalSchema: "PayRolls",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
