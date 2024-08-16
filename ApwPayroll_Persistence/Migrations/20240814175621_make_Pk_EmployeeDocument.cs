using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class make_Pk_EmployeeDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocuments_Documents_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDocuments",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_EmployeeId_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments");

 

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDocuments",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "Id");
 
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocuments_AspNetUsers_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "CreatedBy",
                principalSchema: "PayRolls",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocuments_AspNetUsers_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "UpdatedBy",
                principalSchema: "PayRolls",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocuments_Documents_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "DocumentId",
                principalSchema: "PayRolls",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocuments_AspNetUsers_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocuments_AspNetUsers_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocuments_Documents_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDocuments",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments");
  

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDocuments",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                columns: new[] { "EmployeeId", "DocumentId" });

         
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                columns: new[] { "EmployeeId", "DocumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocuments_Documents_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "DocumentId",
                principalSchema: "PayRolls",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
