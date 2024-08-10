using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ISactivecolumnaddlocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation",
                type: "bit",
                nullable: false,
                defaultValue: false);

        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation");

        }
    }
}
