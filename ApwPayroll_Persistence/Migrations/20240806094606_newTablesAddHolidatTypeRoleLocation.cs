using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newTablesAddHolidatTypeRoleLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidatTypeRoles_Location_LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles");

            migrationBuilder.DropIndex(
                name: "IX_HolidatTypeRoles_LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles");

          

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles");

            migrationBuilder.CreateTable(
                name: "HolidayTypeRuleLocation",
                schema: "PayRolls",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    HolidayRuleTypeId = table.Column<int>(type: "int", nullable: false),
                    HolidayTypeRuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayTypeRuleLocation", x => new { x.LocationId, x.HolidayRuleTypeId });
                    table.ForeignKey(
                        name: "FK_HolidayTypeRuleLocation_HolidatTypeRoles_HolidayRuleTypeId",
                        column: x => x.HolidayRuleTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "HolidatTypeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayTypeRuleLocation_HolidatTypeRoles_HolidayTypeRuleId",
                        column: x => x.HolidayTypeRuleId,
                        principalSchema: "PayRolls",
                        principalTable: "HolidatTypeRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HolidayTypeRuleLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "PayRolls",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

     
            migrationBuilder.CreateIndex(
                name: "IX_HolidayTypeRuleLocation_HolidayRuleTypeId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation",
                column: "HolidayRuleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayTypeRuleLocation_HolidayTypeRuleId",
                schema: "PayRolls",
                table: "HolidayTypeRuleLocation",
                column: "HolidayTypeRuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayTypeRuleLocation",
                schema: "PayRolls");

        

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

       
            migrationBuilder.CreateIndex(
                name: "IX_HolidatTypeRoles_LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidatTypeRoles_Location_LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "LocationId",
                principalSchema: "PayRolls",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
