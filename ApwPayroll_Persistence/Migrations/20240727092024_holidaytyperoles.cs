using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class holidaytyperoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3854806-0542-415c-9d47-316fd0160ebe");

            migrationBuilder.CreateTable(
                name: "HolidatTypeRoles",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidatTypeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidatTypeRoles_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HolidatTypeRoles_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HolidatTypeRoles_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidatTypeRoles_Holidays_HolidayId",
                        column: x => x.HolidayId,
                        principalSchema: "PayRolls",
                        principalTable: "Holidays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidatTypeRoles_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "PayRolls",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d08b7fd7-899f-455b-a96a-32abe394bcff", null, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_HolidatTypeRoles_BranchId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidatTypeRoles_CreatedBy",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HolidatTypeRoles_HolidayId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "HolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidatTypeRoles_LocationId",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidatTypeRoles_UpdatedBy",
                schema: "PayRolls",
                table: "HolidatTypeRoles",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidatTypeRoles",
                schema: "PayRolls");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08b7fd7-899f-455b-a96a-32abe394bcff");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3854806-0542-415c-9d47-316fd0160ebe", null, "Admin", "Admin" });
        }
    }
}
