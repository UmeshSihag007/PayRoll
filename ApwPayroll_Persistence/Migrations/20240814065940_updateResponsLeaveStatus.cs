using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateResponsLeaveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveResponseStatuses_Employees_ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses");

     


            migrationBuilder.AlterColumn<string>(
                name: "ResponseRemark",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResponseDate",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeaveStatus",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

    

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveResponseStatuses_Employees_ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "ResponseById",
                principalSchema: "PayRolls",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveResponseStatuses_Employees_ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses");

       
            migrationBuilder.DropColumn(
                name: "LeaveStatus",
                schema: "PayRolls",
                table: "LeaveResponseStatuses");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseRemark",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResponseDate",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

       
            migrationBuilder.AddForeignKey(
                name: "FK_LeaveResponseStatuses_Employees_ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "ResponseById",
                principalSchema: "PayRolls",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
