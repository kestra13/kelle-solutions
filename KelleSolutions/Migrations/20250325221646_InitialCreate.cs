using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionEntities",
                columns: table => new
                {
                    ActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Due = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Important = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionEntities", x => x.ActionID);
                });

            migrationBuilder.CreateTable(
                name: "Affiliates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
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
                name: "Entities",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operator = table.Column<short>(type: "smallint", nullable: false),
                    Team = table.Column<short>(type: "smallint", nullable: false),
                    Visibility = table.Column<byte>(type: "tinyint", nullable: false),
                    Category = table.Column<short>(type: "smallint", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoNot_Market = table.Column<bool>(type: "bit", nullable: false),
                    DoNot_Contact = table.Column<bool>(type: "bit", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operator = table.Column<short>(type: "smallint", nullable: false),
                    Originator = table.Column<short>(type: "smallint", nullable: false),
                    Team = table.Column<short>(type: "smallint", nullable: false),
                    Visibility = table.Column<byte>(type: "tinyint", nullable: false),
                    Campaign = table.Column<int>(type: "int", nullable: true),
                    Person = table.Column<int>(type: "int", nullable: true),
                    StageWorked = table.Column<bool>(type: "bit", nullable: false),
                    TempWarm = table.Column<bool>(type: "bit", nullable: false),
                    NameFirst = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameMiddle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameLast = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    OrganizationTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    OriginatorFeeRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    OriginatorFeeFixed = table.Column<decimal>(type: "money", nullable: false),
                    DoNotMarket = table.Column<bool>(type: "bit", nullable: false),
                    DoNotContact = table.Column<bool>(type: "bit", nullable: false),
                    Tracking = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PageAccess",
                columns: table => new
                {
                    PageAccessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageAccessName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageAccess", x => x.PageAccessID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResourceType = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    IsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operator = table.Column<short>(type: "smallint", nullable: false),
                    Team = table.Column<short>(type: "smallint", nullable: false),
                    Visibility = table.Column<byte>(type: "tinyint", nullable: false),
                    Category = table.Column<short>(type: "smallint", nullable: false),
                    MySource = table.Column<short>(type: "smallint", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false),
                    NameFirst = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameMiddle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameLast = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameDisplay = table.Column<string>(type: "nvarchar(92)", maxLength: 92, nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EmailPrimary = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EmailSecondary = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EmailPrimaryLabel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailSecondaryLabel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhonePrimary = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneSecondary = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhonePrimaryLabel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneSecondaryLabel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoNotMarket = table.Column<bool>(type: "bit", nullable: false),
                    DoNotContact = table.Column<bool>(type: "bit", nullable: false),
                    Tracking = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Visibility = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<short>(type: "smallint", nullable: false),
                    Team = table.Column<short>(type: "smallint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MyType = table.Column<short>(type: "smallint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    StateProvince = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    County = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Residential = table.Column<bool>(type: "bit", nullable: false),
                    Beds = table.Column<byte>(type: "tinyint", nullable: true),
                    Baths = table.Column<byte>(type: "tinyint", nullable: true),
                    BathsPartial = table.Column<byte>(type: "tinyint", nullable: true),
                    Garages = table.Column<byte>(type: "tinyint", nullable: true),
                    Constructed = table.Column<short>(type: "smallint", nullable: true),
                    Remodeled = table.Column<short>(type: "smallint", nullable: true),
                    SqFt_Land = table.Column<int>(type: "int", nullable: true),
                    SqFt_Building = table.Column<int>(type: "int", nullable: true),
                    APN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "StatusMappings",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusCode = table.Column<short>(type: "smallint", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMappings", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseOperator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppraisalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransitionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroups",
                columns: table => new
                {
                    PermissionGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ParentGroupID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroups", x => x.PermissionGroupID);
                    table.ForeignKey(
                        name: "FK_PermissionGroups_PermissionGroups_ParentGroupID",
                        column: x => x.ParentGroupID,
                        principalTable: "PermissionGroups",
                        principalColumn: "PermissionGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionGroups_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonToAffiliations",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deprecated = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<short>(type: "smallint", nullable: false),
                    Person = table.Column<int>(type: "int", nullable: false),
                    Affiliate = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<short>(type: "smallint", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToAffiliations", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PersonToAffiliations_Affiliates_Affiliate",
                        column: x => x.Affiliate,
                        principalTable: "Affiliates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToAffiliations_Person_Person",
                        column: x => x.Person,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonToEntity",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deprecated = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<short>(type: "smallint", nullable: false),
                    Person = table.Column<int>(type: "int", nullable: false),
                    Entity = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<short>(type: "smallint", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToEntity", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PersonToEntity_Entities_Entity",
                        column: x => x.Entity,
                        principalTable: "Entities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToEntity_Person_Person",
                        column: x => x.Person,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonToLeads",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deprecated = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<short>(type: "smallint", nullable: false),
                    Person = table.Column<int>(type: "int", nullable: false),
                    Lead = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<short>(type: "smallint", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToLeads", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PersonToLeads_Leads_Lead",
                        column: x => x.Lead,
                        principalTable: "Leads",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToLeads_Person_Person",
                        column: x => x.Person,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonToPerson",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deprecated = table.Column<bool>(type: "bit", nullable: false),
                    DateTime2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<short>(type: "smallint", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Person2Id = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<short>(type: "smallint", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToPerson", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PersonToPerson_Person_Person2Id",
                        column: x => x.Person2Id,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Property = table.Column<int>(type: "int", nullable: false),
                    MyStatus = table.Column<short>(type: "smallint", nullable: false),
                    MySource = table.Column<short>(type: "smallint", nullable: false),
                    Operator = table.Column<short>(type: "smallint", nullable: false),
                    Team = table.Column<short>(type: "smallint", nullable: false),
                    Visibility = table.Column<byte>(type: "tinyint", nullable: false),
                    ExternalListing = table.Column<bool>(type: "bit", nullable: true),
                    PocketListing = table.Column<bool>(type: "bit", nullable: true),
                    OnMarket = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Listed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Accepted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Closed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Price_Actual = table.Column<decimal>(type: "money", nullable: true),
                    CommissionRate = table.Column<decimal>(type: "decimal(6,4)", nullable: true),
                    CommissionFixed = table.Column<decimal>(type: "money", nullable: true),
                    CommissionActual = table.Column<decimal>(type: "money", nullable: true),
                    DisplayOnWebsite = table.Column<bool>(type: "bit", nullable: true),
                    DisplayPriority = table.Column<byte>(type: "tinyint", nullable: true),
                    MLS_ID = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    MLS_URL = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true),
                    Comments = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Listings_Properties_Property",
                        column: x => x.Property,
                        principalTable: "Properties",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonToProperties",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deprecated = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Creator = table.Column<short>(type: "smallint", nullable: false),
                    Person = table.Column<int>(type: "int", nullable: false),
                    Properties = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<short>(type: "smallint", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToProperties", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PersonToProperties_Person_Person",
                        column: x => x.Person,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToProperties_Properties_Properties",
                        column: x => x.Properties,
                        principalTable: "Properties",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellerIDMappings",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerIDMappings", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SellerIDMappings_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerIDMappings_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Affiliation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsTenant = table.Column<bool>(type: "bit", nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Tenant_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionGroupEntity",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PermissionGroupID = table.Column<int>(type: "int", nullable: false),
                    PageAccessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionGroupEntity", x => new { x.RoleID, x.PermissionGroupID, x.PageAccessID });
                    table.ForeignKey(
                        name: "FK_RolePermissionGroupEntity_PageAccess_PageAccessID",
                        column: x => x.PageAccessID,
                        principalTable: "PageAccess",
                        principalColumn: "PageAccessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionGroupEntity_PermissionGroups_PermissionGroupID",
                        column: x => x.PermissionGroupID,
                        principalTable: "PermissionGroups",
                        principalColumn: "PermissionGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionGroupEntity_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonToListing",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ListingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToListing", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PersonToListing_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToListing_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
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
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dashboards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantToPeople",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TenantToPersonID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantToPeople", x => new { x.TenantID, x.PersonID });
                    table.ForeignKey(
                        name: "FK_TenantToPeople_AspNetUsers_PersonID",
                        column: x => x.PersonID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TenantToPeople_Tenant_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "825e22ab-17b8-40ca-ad29-2cfe36c6ee6d", null, "Agent", "AGENT" },
                    { "8966c7de-78ce-4138-b008-c77516a1f4a7", null, "Admin", "ADMIN" },
                    { "f5aee51e-7e93-4287-a80c-b32e21965659", null, "Broker", "BROKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleID",
                table: "AspNetUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantID",
                table: "AspNetUsers",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UserId",
                table: "Dashboards",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Property",
                table: "Listings",
                column: "Property");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroups_ParentGroupID",
                table: "PermissionGroups",
                column: "ParentGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroups_PermissionID",
                table: "PermissionGroups",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToAffiliations_Affiliate",
                table: "PersonToAffiliations",
                column: "Affiliate");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToAffiliations_Person",
                table: "PersonToAffiliations",
                column: "Person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToEntity_Entity",
                table: "PersonToEntity",
                column: "Entity");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToEntity_Person",
                table: "PersonToEntity",
                column: "Person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToLeads_Lead",
                table: "PersonToLeads",
                column: "Lead");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToLeads_Person",
                table: "PersonToLeads",
                column: "Person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToListing_ListingId",
                table: "PersonToListing",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToListing_PersonId",
                table: "PersonToListing",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToPerson_Person2Id",
                table: "PersonToPerson",
                column: "Person2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToPerson_PersonId",
                table: "PersonToPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToProperties_Person",
                table: "PersonToProperties",
                column: "Person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToProperties_Properties",
                table: "PersonToProperties",
                column: "Properties");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionGroupEntity_PageAccessID",
                table: "RolePermissionGroupEntity",
                column: "PageAccessID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionGroupEntity_PermissionGroupID",
                table: "RolePermissionGroupEntity",
                column: "PermissionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerIDMappings_PersonID",
                table: "SellerIDMappings",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerIDMappings_PropertyID",
                table: "SellerIDMappings",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_TenantToPeople_PersonID",
                table: "TenantToPeople",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionEntities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "PersonToAffiliations");

            migrationBuilder.DropTable(
                name: "PersonToEntity");

            migrationBuilder.DropTable(
                name: "PersonToLeads");

            migrationBuilder.DropTable(
                name: "PersonToListing");

            migrationBuilder.DropTable(
                name: "PersonToPerson");

            migrationBuilder.DropTable(
                name: "PersonToProperties");

            migrationBuilder.DropTable(
                name: "RolePermissionGroupEntity");

            migrationBuilder.DropTable(
                name: "SellerIDMappings");

            migrationBuilder.DropTable(
                name: "StatusMappings");

            migrationBuilder.DropTable(
                name: "TenantToPeople");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Affiliates");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "PageAccess");

            migrationBuilder.DropTable(
                name: "PermissionGroups");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
