using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_coloumn_EmployeeDocumenttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.DropColumn(
                name: "IsCodeRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "IsDocumentRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "IsCodeRequired",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDocumentRequired",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
 

            migrationBuilder.DropColumn(
                name: "IsCodeRequired",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "IsDocumentRequired",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes");

            migrationBuilder.AddColumn<bool>(
                name: "IsCodeRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDocumentRequired",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            
        }
    }
}
