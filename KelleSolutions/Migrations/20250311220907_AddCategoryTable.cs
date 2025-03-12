using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4845225c-5b23-407f-b777-a27253313ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1572c26-061e-4cb9-abe3-75e0f0bed7a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa2b1cff-ad1c-416c-8384-29db8bd1d51e");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "People",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17cdbbae-589e-4854-95c6-f4146aaa6e02", null, "Agent", "AGENT" },
                    { "4712485b-df65-411b-b342-aac6d19ee935", null, "Admin", "ADMIN" },
                    { "bdc53b95-8343-432e-bfd0-3940a60e3576", null, "Broker", "BROKER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { (short)1, "Admin" },
                    { (short)2, "Broker" },
                    { (short)3, "Tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CategoryId",
                table: "People",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Categories_CategoryId",
                table: "People",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Categories_CategoryId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_People_CategoryId",
                table: "People");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17cdbbae-589e-4854-95c6-f4146aaa6e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4712485b-df65-411b-b342-aac6d19ee935");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc53b95-8343-432e-bfd0-3940a60e3576");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "People",
                newName: "Category");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4845225c-5b23-407f-b777-a27253313ad2", null, "Admin", "ADMIN" },
                    { "a1572c26-061e-4cb9-abe3-75e0f0bed7a2", null, "Agent", "AGENT" },
                    { "fa2b1cff-ad1c-416c-8384-29db8bd1d51e", null, "Broker", "BROKER" }
                });
        }
    }
}
