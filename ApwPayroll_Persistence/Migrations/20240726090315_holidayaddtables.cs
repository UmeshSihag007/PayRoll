using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class holidayaddtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ef5a532-fab0-468e-9a4e-1df9596f10cb");

            migrationBuilder.CreateTable(
                name: "HolidayTypes",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HolidayTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotifyToEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsResetToLeaveRequest = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Holidays_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Holidays_HolidayTypes_HolidayTypeId",
                        column: x => x.HolidayTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "HolidayTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsHalfDay = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leaves_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leaves_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypeRoles",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MaxMonthLeave = table.Column<long>(type: "bigint", nullable: false),
                    MaxYearLeave = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTypeRoles_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRoles_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRoles_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveTypeRoles_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "PayRolls",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveTypeRoles_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveResponseStatuses",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveId = table.Column<int>(type: "int", nullable: false),
                    ResponseById = table.Column<int>(type: "int", nullable: false),
                    ResponseRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForwordId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveResponseStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveResponseStatuses_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveResponseStatuses_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveResponseStatuses_Employees_ForwordId",
                        column: x => x.ForwordId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveResponseStatuses_Employees_ResponseById",
                        column: x => x.ResponseById,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveResponseStatuses_Leaves_LeaveId",
                        column: x => x.LeaveId,
                        principalSchema: "PayRolls",
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3854806-0542-415c-9d47-316fd0160ebe", null, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_CreatedBy",
                schema: "PayRolls",
                table: "Holidays",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_HolidayTypeId",
                schema: "PayRolls",
                table: "Holidays",
                column: "HolidayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_UpdatedBy",
                schema: "PayRolls",
                table: "Holidays",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayTypes_CreatedBy",
                schema: "PayRolls",
                table: "HolidayTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayTypes_UpdatedBy",
                schema: "PayRolls",
                table: "HolidayTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponseStatuses_CreatedBy",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponseStatuses_ForwordId",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "ForwordId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponseStatuses_LeaveId",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "LeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponseStatuses_ResponseById",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "ResponseById");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveResponseStatuses_UpdatedBy",
                schema: "PayRolls",
                table: "LeaveResponseStatuses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_CreatedBy",
                schema: "PayRolls",
                table: "Leaves",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_LeaveTypeId",
                schema: "PayRolls",
                table: "Leaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UpdatedBy",
                schema: "PayRolls",
                table: "Leaves",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRoles_BranchId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRoles_CreatedBy",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRoles_DesignationId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRoles_LeaveTypeId",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRoles_UpdatedBy",
                schema: "PayRolls",
                table: "LeaveTypeRoles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_CreatedBy",
                schema: "PayRolls",
                table: "LeaveTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_UpdatedBy",
                schema: "PayRolls",
                table: "LeaveTypes",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "LeaveResponseStatuses",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "LeaveTypeRoles",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "HolidayTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Leaves",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "LeaveTypes",
                schema: "PayRolls");

            migrationBuilder.DeleteData(
                schema: "PayRolls",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3854806-0542-415c-9d47-316fd0160ebe");

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ef5a532-fab0-468e-9a4e-1df9596f10cb", null, "Admin", "Admin" });
        }
    }
}
