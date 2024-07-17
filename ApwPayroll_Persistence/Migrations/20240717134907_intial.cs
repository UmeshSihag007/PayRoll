using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApwPayroll_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PayRolls");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AddressTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "PayRolls",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "PayRolls",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "PayRolls",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchDocumentTypes",
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
                    table.PrimaryKey("PK_BranchDocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchDocumentTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchDocumentTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
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
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Checklist",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checklist_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checklist_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checklist_Checklist_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "PayRolls",
                        principalTable: "Checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
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
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
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
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designation_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Designation_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocumentTypes",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDocumentTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeDocumentTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuTypes",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
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
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
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
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelationTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelationTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTagTypes",
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
                    table.PrimaryKey("PK_TemplateTagTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateTagTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateTagTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTypes",
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
                    table.PrimaryKey("PK_TemplateTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BranchesAddresses",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    LocatioinId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesAddresses_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesAddresses_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesAddresses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesContacts",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesContacts_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesContacts_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesContacts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchNumberFormats",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    FormatType = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchNumberFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchNumberFormats_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchNumberFormats_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchNumberFormats_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESINumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceNumber = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AspUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsBrokerExamPass = table.Column<bool>(type: "bit", nullable: true),
                    StartedSalary = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salutation = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    IsLoginAccess = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharNumber = table.Column<long>(type: "bigint", nullable: true),
                    RationCardNumber = table.Column<long>(type: "bigint", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UanNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_AspUserId",
                        column: x => x.AspUserId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "PayRolls",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MenuTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menu_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menu_MenuTypes_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "MenuTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "PayRolls",
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTags",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateTags_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateTags_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateTags_TemplateTagTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "PayRolls",
                        principalTable: "TemplateTagTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Templates_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Templates_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Templates_TemplateTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "PayRolls",
                        principalTable: "TemplateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BanAccountId = table.Column<int>(type: "int", nullable: false),
                    IsBankAccountVerified = table.Column<bool>(type: "bit", nullable: false),
                    IFCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    AccountBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankDetails_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsBankAccountVerified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    IFCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Banks_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Banks_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Banks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: true),
                    WhatsAppNumber = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_RelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddresses",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeChecklists",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CheckListId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeChecklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeChecklists_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeChecklists_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeChecklists_Checklist_CheckListId",
                        column: x => x.CheckListId,
                        principalSchema: "PayRolls",
                        principalTable: "Checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeChecklists_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContacts",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    WhatsAppNumber = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartments",
                schema: "PayRolls",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartments", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "PayRolls",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDesignations",
                schema: "PayRolls",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDesignations", x => new { x.EmployeeId, x.DesignationId });
                    table.ForeignKey(
                        name: "FK_EmployeeDesignations_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "PayRolls",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDesignations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExperiences",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ComanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualInCome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeExperiences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExperiences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExperiences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFamilies",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFamilies_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFamilies_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFamilies_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeFamilies_RelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLanguages",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsWrite = table.Column<bool>(type: "bit", nullable: false),
                    IsSpeak = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguages_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguages_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLicenses",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLicenses_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLicenses_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLicenses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePersonalDetails",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<int>(type: "int", nullable: false),
                    MarriedStatus = table.Column<int>(type: "int", nullable: false),
                    DateOfWedding = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePersonalDetails_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePersonalDetails_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePersonalDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeQualifications",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    UniversityBoard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObtainMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GradeType = table.Column<int>(type: "int", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "PayRolls",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSocials",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LinkdinUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaceBookUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSocials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSocials_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSocials_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSocials_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferralDetails",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReferenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    YearsOfAcquaintance = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralDetails_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReferralDetails_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReferralDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesDocuments",
                schema: "PayRolls",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesDocuments", x => new { x.BranchId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_BranchesDocuments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "PayRolls",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchesDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "PayRolls",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Certificates_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Certificates_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "PayRolls",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocuments",
                schema: "PayRolls",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeDocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocuments", x => new { x.EmployeeId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "PayRolls",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_EmployeeDocumentTypes_EmployeeDocumentTypeId",
                        column: x => x.EmployeeDocumentTypeId,
                        principalSchema: "PayRolls",
                        principalTable: "EmployeeDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "PayRolls",
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalSchema: "PayRolls",
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateBody",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateBody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateBody_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateBody_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemplateBody_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalSchema: "PayRolls",
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateBody_Templates_TemplateId1",
                        column: x => x.TemplateId1,
                        principalSchema: "PayRolls",
                        principalTable: "Templates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateDocument",
                schema: "PayRolls",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    TemplateId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDocument", x => new { x.DocumentId, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_TemplateDocument_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "PayRolls",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateDocument_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalSchema: "PayRolls",
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateDocument_Templates_TemplateId1",
                        column: x => x.TemplateId1,
                        principalSchema: "PayRolls",
                        principalTable: "Templates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalSchema: "PayRolls",
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Training_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationListeners",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    IsSended = table.Column<bool>(type: "bit", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationListeners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationListeners_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationListeners_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationListeners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationListeners_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PayRolls",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationListeners_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "PayRolls",
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLogs",
                schema: "PayRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationLogs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationLogs_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PayRolls",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationLogs_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "PayRolls",
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "PayRolls",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90cc5ac5-8997-408f-a1d4-be68c2c720cc", null, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_CreatedBy",
                schema: "PayRolls",
                table: "AddressTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_UpdatedBy",
                schema: "PayRolls",
                table: "AddressTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "PayRolls",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "PayRolls",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "PayRolls",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "PayRolls",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "PayRolls",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "PayRolls",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "PayRolls",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CreatedBy",
                schema: "PayRolls",
                table: "BankDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_EmployeeId",
                schema: "PayRolls",
                table: "BankDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_UpdatedBy",
                schema: "PayRolls",
                table: "BankDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_BranchId",
                schema: "PayRolls",
                table: "Banks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CreatedBy",
                schema: "PayRolls",
                table: "Banks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_EmployeeId",
                schema: "PayRolls",
                table: "Banks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_UpdatedBy",
                schema: "PayRolls",
                table: "Banks",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchDocumentTypes_CreatedBy",
                schema: "PayRolls",
                table: "BranchDocumentTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchDocumentTypes_UpdatedBy",
                schema: "PayRolls",
                table: "BranchDocumentTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CreatedBy",
                schema: "PayRolls",
                table: "Branches",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_UpdatedBy",
                schema: "PayRolls",
                table: "Branches",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesAddresses_BranchId",
                schema: "PayRolls",
                table: "BranchesAddresses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesAddresses_CreatedBy",
                schema: "PayRolls",
                table: "BranchesAddresses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesAddresses_UpdatedBy",
                schema: "PayRolls",
                table: "BranchesAddresses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesContacts_BranchId",
                schema: "PayRolls",
                table: "BranchesContacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesContacts_CreatedBy",
                schema: "PayRolls",
                table: "BranchesContacts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesContacts_UpdatedBy",
                schema: "PayRolls",
                table: "BranchesContacts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesDocuments_DocumentId",
                schema: "PayRolls",
                table: "BranchesDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchNumberFormats_BranchId",
                schema: "PayRolls",
                table: "BranchNumberFormats",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchNumberFormats_CreatedBy",
                schema: "PayRolls",
                table: "BranchNumberFormats",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BranchNumberFormats_UpdatedBy",
                schema: "PayRolls",
                table: "BranchNumberFormats",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CreatedBy",
                schema: "PayRolls",
                table: "Certificates",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_DocumentId",
                schema: "PayRolls",
                table: "Certificates",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UpdatedBy",
                schema: "PayRolls",
                table: "Certificates",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_CreatedBy",
                schema: "PayRolls",
                table: "Checklist",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_ParentId",
                schema: "PayRolls",
                table: "Checklist",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_UpdatedBy",
                schema: "PayRolls",
                table: "Checklist",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_CreatedBy",
                schema: "PayRolls",
                table: "ContactTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_UpdatedBy",
                schema: "PayRolls",
                table: "ContactTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedBy",
                schema: "PayRolls",
                table: "Courses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UpdatedBy",
                schema: "PayRolls",
                table: "Courses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedBy",
                schema: "PayRolls",
                table: "Departments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedBy",
                schema: "PayRolls",
                table: "Departments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_CreatedBy",
                schema: "PayRolls",
                table: "Designation",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_UpdatedBy",
                schema: "PayRolls",
                table: "Designation",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatedBy",
                schema: "PayRolls",
                table: "Documents",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                schema: "PayRolls",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UpdatedBy",
                schema: "PayRolls",
                table: "Documents",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_CreatedBy",
                schema: "PayRolls",
                table: "DocumentTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_UpdatedBy",
                schema: "PayRolls",
                table: "DocumentTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_CreatedBy",
                schema: "PayRolls",
                table: "EmergencyContacts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_EmployeeId",
                schema: "PayRolls",
                table: "EmergencyContacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_RelationTypeId",
                schema: "PayRolls",
                table: "EmergencyContacts",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_UpdatedBy",
                schema: "PayRolls",
                table: "EmergencyContacts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_AddressTypeId",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeAddresses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChecklists_CheckListId",
                schema: "PayRolls",
                table: "EmployeeChecklists",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChecklists_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeChecklists",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChecklists_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeChecklists",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChecklists_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeChecklists",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_ContactTypeId",
                schema: "PayRolls",
                table: "EmployeeContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeContacts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeContacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeContacts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_DepartmentId_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeDepartments",
                columns: new[] { "DepartmentId", "EmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignations_DesignationId_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeDesignations",
                columns: new[] { "DesignationId", "EmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeDocumentTypeId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                column: "EmployeeDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId_DocumentId",
                schema: "PayRolls",
                table: "EmployeeDocuments",
                columns: new[] { "EmployeeId", "DocumentId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocumentTypes_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocumentTypes_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeDocumentTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExperiences_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeExperiences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExperiences_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeExperiences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExperiences_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeExperiences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilies_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeFamilies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilies_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeFamilies",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilies_RelationTypeId",
                schema: "PayRolls",
                table: "EmployeeFamilies",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilies_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeFamilies",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeLanguages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeLanguages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeLanguages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLicenses_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeLicenses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLicenses_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeLicenses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLicenses_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeLicenses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePersonalDetails_CreatedBy",
                schema: "PayRolls",
                table: "EmployeePersonalDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePersonalDetails_EmployeeId",
                schema: "PayRolls",
                table: "EmployeePersonalDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePersonalDetails_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeePersonalDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_CourseId",
                schema: "PayRolls",
                table: "EmployeeQualifications",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeQualifications",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeQualifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeQualifications",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AspUserId",
                schema: "PayRolls",
                table: "Employees",
                column: "AspUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                schema: "PayRolls",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                schema: "PayRolls",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UpdatedBy",
                schema: "PayRolls",
                table: "Employees",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSocials_CreatedBy",
                schema: "PayRolls",
                table: "EmployeeSocials",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSocials_EmployeeId",
                schema: "PayRolls",
                table: "EmployeeSocials",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSocials_UpdatedBy",
                schema: "PayRolls",
                table: "EmployeeSocials",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CreatedBy",
                schema: "PayRolls",
                table: "Menu",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuTypeId",
                schema: "PayRolls",
                table: "Menu",
                column: "MenuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                schema: "PayRolls",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_UpdatedBy",
                schema: "PayRolls",
                table: "Menu",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypes_CreatedBy",
                schema: "PayRolls",
                table: "MenuTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTypes_UpdatedBy",
                schema: "PayRolls",
                table: "MenuTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationListeners_CreatedBy",
                schema: "PayRolls",
                table: "NotificationListeners",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationListeners_EmployeeId",
                schema: "PayRolls",
                table: "NotificationListeners",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationListeners_NotificationId",
                schema: "PayRolls",
                table: "NotificationListeners",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationListeners_UpdatedBy",
                schema: "PayRolls",
                table: "NotificationListeners",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationListeners_UserId",
                schema: "PayRolls",
                table: "NotificationListeners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_CreatedBy",
                schema: "PayRolls",
                table: "NotificationLogs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_NotificationId",
                schema: "PayRolls",
                table: "NotificationLogs",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_UpdatedBy",
                schema: "PayRolls",
                table: "NotificationLogs",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedBy",
                schema: "PayRolls",
                table: "Notifications",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TemplateId",
                schema: "PayRolls",
                table: "Notifications",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TypeId",
                schema: "PayRolls",
                table: "Notifications",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UpdatedBy",
                schema: "PayRolls",
                table: "Notifications",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTypes_CreatedBy",
                schema: "PayRolls",
                table: "NotificationTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTypes_UpdatedBy",
                schema: "PayRolls",
                table: "NotificationTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralDetails_CreatedBy",
                schema: "PayRolls",
                table: "ReferralDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralDetails_EmployeeId",
                schema: "PayRolls",
                table: "ReferralDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralDetails_UpdatedBy",
                schema: "PayRolls",
                table: "ReferralDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RelationTypes_CreatedBy",
                schema: "PayRolls",
                table: "RelationTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RelationTypes_UpdatedBy",
                schema: "PayRolls",
                table: "RelationTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateBody_CreatedBy",
                schema: "PayRolls",
                table: "TemplateBody",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateBody_TemplateId",
                schema: "PayRolls",
                table: "TemplateBody",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateBody_TemplateId1",
                schema: "PayRolls",
                table: "TemplateBody",
                column: "TemplateId1",
                unique: true,
                filter: "[TemplateId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateBody_UpdatedBy",
                schema: "PayRolls",
                table: "TemplateBody",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDocument_TemplateId",
                schema: "PayRolls",
                table: "TemplateDocument",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDocument_TemplateId1",
                schema: "PayRolls",
                table: "TemplateDocument",
                column: "TemplateId1");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_CreatedBy",
                schema: "PayRolls",
                table: "Templates",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TypeId",
                schema: "PayRolls",
                table: "Templates",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_UpdatedBy",
                schema: "PayRolls",
                table: "Templates",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTags_CreatedBy",
                schema: "PayRolls",
                table: "TemplateTags",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTags_TypeId",
                schema: "PayRolls",
                table: "TemplateTags",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTags_UpdatedBy",
                schema: "PayRolls",
                table: "TemplateTags",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTagTypes_CreatedBy",
                schema: "PayRolls",
                table: "TemplateTagTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTagTypes_UpdatedBy",
                schema: "PayRolls",
                table: "TemplateTagTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTypes_CreatedBy",
                schema: "PayRolls",
                table: "TemplateTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTypes_UpdatedBy",
                schema: "PayRolls",
                table: "TemplateTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Training_CertificateId",
                schema: "PayRolls",
                table: "Training",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_CreatedBy",
                schema: "PayRolls",
                table: "Training",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Training_EmployeeId",
                schema: "PayRolls",
                table: "Training",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UpdatedBy",
                schema: "PayRolls",
                table: "Training",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "BankDetails",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "BranchDocumentTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "BranchesAddresses",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "BranchesContacts",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "BranchesDocuments",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "BranchNumberFormats",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmergencyContacts",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeAddresses",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeChecklists",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeContacts",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeDepartments",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeDesignations",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeDocuments",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeExperiences",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeFamilies",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeLanguages",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeLicenses",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeePersonalDetails",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeQualifications",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeSocials",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "NotificationListeners",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "NotificationLogs",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "ReferralDetails",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "TemplateBody",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "TemplateDocument",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "TemplateTags",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Training",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AddressTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Checklist",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "EmployeeDocumentTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "RelationTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "MenuTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "TemplateTagTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Certificates",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "NotificationTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Templates",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "TemplateTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "PayRolls");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "PayRolls");
        }
    }
}
