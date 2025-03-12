using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class AddPeopleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a09ee82-3bcf-461f-8f58-65684e773c6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e6b2cd-90e2-4609-906a-175ef67377c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d359bc97-b831-4af2-9f40-dddb63a6857e");

            migrationBuilder.CreateTable(
                name: "People",
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
                    Name_First = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Name_Middle = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Name_Last = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Name_Display = table.Column<string>(type: "nvarchar(92)", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Email_Primary = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Email_Secondary = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Email_Primary_Label = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email_Secondary_Label = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Phone_Primary = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Phone_Secondary = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Phone_Primary_Label = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Phone_Secondary_Label = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DoNot_Market = table.Column<bool>(type: "bit", nullable: false),
                    DoNot_Contact = table.Column<bool>(type: "bit", nullable: false),
                    Tracking = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(2048)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "401827b2-c0d0-4ded-908a-702e75be9e99", null, "Admin", "ADMIN" },
                    { "5ae6cfbc-d96e-499d-b0e7-3e9cda39b953", null, "Broker", "BROKER" },
                    { "a0a298dd-e201-4532-8b8e-1a3d65fb6c83", null, "Agent", "AGENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401827b2-c0d0-4ded-908a-702e75be9e99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae6cfbc-d96e-499d-b0e7-3e9cda39b953");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0a298dd-e201-4532-8b8e-1a3d65fb6c83");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a09ee82-3bcf-461f-8f58-65684e773c6a", null, "Agent", "AGENT" },
                    { "80e6b2cd-90e2-4609-906a-175ef67377c4", null, "Admin", "ADMIN" },
                    { "d359bc97-b831-4af2-9f40-dddb63a6857e", null, "Broker", "BROKER" }
                });
        }
    }
}
