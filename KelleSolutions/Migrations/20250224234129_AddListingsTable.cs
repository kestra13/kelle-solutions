using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class AddListingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422a2516-0cc8-4596-a024-8193bee7687a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72f3d80c-94aa-40f6-b4bf-a425f5fed939");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c853a50f-b497-4b2e-8058-9fc46defaf90");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TenantID",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTenant",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TenantID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("IF OBJECT_ID(N'dbo.Listings', N'U') IS NOT NULL DROP TABLE dbo.Listings;");

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    AgentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingID);
                    table.ForeignKey(
                        name: "FK_Listings_AspNetUsers_AgentID",
                        column: x => x.AgentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.Sql("DROP TABLE IF EXISTS dbo.Tenant;");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ee4b4ed-89de-4574-aa75-b7823d35b11d", null, "Admin", "ADMIN" },
                    { "b8f64e79-d4a7-4f99-a8ff-96ba8c1249c9", null, "Agent", "AGENT" },
                    { "e7e85d3c-fb39-4a56-91b7-f699daffa2ec", null, "Broker", "BROKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TenantID",
                table: "Properties",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantID",
                table: "AspNetUsers",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_AgentID",
                table: "Listings",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_PropertyID",
                table: "Listings",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantID",
                table: "AspNetUsers",
                column: "TenantID",
                principalTable: "Tenant",
                principalColumn: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Tenant_TenantID",
                table: "Properties",
                column: "TenantID",
                principalTable: "Tenant",
                principalColumn: "TenantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Tenant_TenantID",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Properties_TenantID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ee4b4ed-89de-4574-aa75-b7823d35b11d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8f64e79-d4a7-4f99-a8ff-96ba8c1249c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e85d3c-fb39-4a56-91b7-f699daffa2ec");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsTenant",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "422a2516-0cc8-4596-a024-8193bee7687a", null, "Broker", "Broker" },
                    { "72f3d80c-94aa-40f6-b4bf-a425f5fed939", null, "Admin", "Admin" },
                    { "c853a50f-b497-4b2e-8058-9fc46defaf90", null, "Agent", "Agent" }
                });
        }
    }
}
