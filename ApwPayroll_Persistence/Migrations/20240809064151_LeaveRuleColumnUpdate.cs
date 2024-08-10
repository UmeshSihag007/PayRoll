using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LeaveRuleColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AlterColumn<long>(
                name: "MaxYearLeave",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MaxMonthLeave",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                schema: "PayRolls",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                schema: "PayRolls",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.DropColumn(
                name: "FromDate",
                schema: "PayRolls",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "ToDate",
                schema: "PayRolls",
                table: "Leaves");

            migrationBuilder.AlterColumn<long>(
                name: "MaxYearLeave",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MaxMonthLeave",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);


        }
    }
}
