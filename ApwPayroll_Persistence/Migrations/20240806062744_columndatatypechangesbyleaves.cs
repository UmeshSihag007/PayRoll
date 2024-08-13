using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class columndatatypechangesbyleaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AlterColumn<int>(
                name: "LeaveStatus",
                schema: "PayRolls",
                table: "Leaves",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

       }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AlterColumn<bool>(
                name: "LeaveStatus",
                schema: "PayRolls",
                table: "Leaves",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

        }
    }
}
