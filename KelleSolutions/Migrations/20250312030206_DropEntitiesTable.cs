using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class DropEntitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name:"Entities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cacba36-e849-418f-972a-62b6278076d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3ecb45-48b3-4abc-a386-9d32d6e90bba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6107027-a734-4b50-8ce8-78ee2b3538e6");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0542e2fd-ef68-4517-9de1-3430a3be5ced");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "338068ba-92b2-4e28-97a1-1eefdeb81735");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d88ebc0c-e51f-4508-b95c-d7f21d981c53");
            
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(maxLength: 80, nullable: false),
                    Category = table.Column<short>(nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 40, nullable: false),
                    StateProvince = table.Column<string>(maxLength: 2, nullable: false),
                    Country = table.Column<string>(maxLength: 3, nullable: false),
                    Postal = table.Column<string>(maxLength: 10, nullable: false),
                    Street = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Updated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Archived = table.Column<bool>(nullable: false, defaultValue: false),
                    Bio = table.Column<string>(nullable: true, maxLength: int.MaxValue),
                    Comments = table.Column<string>(nullable: true, maxLength: 2048),
                    Website = table.Column<string>(nullable: true, maxLength: 2048),
                    Visibility = table.Column<byte>(nullable: true),
                    DoNot_Market = table.Column<bool>(nullable: false, defaultValue: false),
                    DoNot_Contact = table.Column<bool>(nullable: false, defaultValue: false),
                    Team = table.Column<short>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Code);
                });
                }
    }
}
