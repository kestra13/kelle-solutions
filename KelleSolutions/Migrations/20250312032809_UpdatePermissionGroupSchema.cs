using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionGroupSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionGroups_PermissionGroups_ParentGroupID",
                table: "PermissionGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18b20bf0-2f7d-4d10-861a-38d1fd3741c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38c93c14-2925-4409-8dc5-60d2d5e5853c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa64826-bba4-4622-bc11-7b3aa383aa94");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceType",
                table: "Permissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Action",
                table: "Permissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PermissionGroups",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "PermissionGroups",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "421751dc-2f16-44de-b2b0-642eadeef301", null, "Admin", "ADMIN" },
                    { "9d5148bf-af34-4b9b-a40c-e7a50639f52d", null, "Agent", "AGENT" },
                    { "e9fb3bf4-62b1-4743-b522-a99fc2330e80", null, "Broker", "BROKER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionGroups_PermissionGroups_ParentGroupID",
                table: "PermissionGroups",
                column: "ParentGroupID",
                principalTable: "PermissionGroups",
                principalColumn: "PermissionGroupID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionGroups_PermissionGroups_ParentGroupID",
                table: "PermissionGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "421751dc-2f16-44de-b2b0-642eadeef301");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d5148bf-af34-4b9b-a40c-e7a50639f52d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9fb3bf4-62b1-4743-b522-a99fc2330e80");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PermissionGroups");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "PermissionGroups");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceType",
                table: "Permissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Permissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18b20bf0-2f7d-4d10-861a-38d1fd3741c5", null, "Admin", "ADMIN" },
                    { "38c93c14-2925-4409-8dc5-60d2d5e5853c", null, "Broker", "BROKER" },
                    { "6fa64826-bba4-4622-bc11-7b3aa383aa94", null, "Agent", "AGENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionGroups_PermissionGroups_ParentGroupID",
                table: "PermissionGroups",
                column: "ParentGroupID",
                principalTable: "PermissionGroups",
                principalColumn: "PermissionGroupID");
        }
    }
}
