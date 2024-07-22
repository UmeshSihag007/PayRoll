using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTable_Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f7aca7-ad40-4593-bc48-5a7e51bb0cc5");

            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "PayRolls",
                table: "BankDetails");

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Location_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "PayRolls",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd939fbd-4728-4c1f-a6e4-f436751b4466", null, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreatedBy",
                schema: "PayRolls",
                table: "Location",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ParentId",
                schema: "PayRolls",
                table: "Location",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UpdatedBy",
                schema: "PayRolls",
                table: "Location",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location",
                schema: "PayRolls");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd939fbd-4728-4c1f-a6e4-f436751b4466");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "PayRolls",
                table: "BankDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6f7aca7-ad40-4593-bc48-5a7e51bb0cc5", null, "Admin", "Admin" });
        }
    }
}
