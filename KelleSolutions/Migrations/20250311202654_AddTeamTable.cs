using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelleSolutions.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Affiliation = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4845225c-5b23-407f-b777-a27253313ad2", null, "Admin", "ADMIN" },
                    { "a1572c26-061e-4cb9-abe3-75e0f0bed7a2", null, "Agent", "AGENT" },
                    { "fa2b1cff-ad1c-416c-8384-29db8bd1d51e", null, "Broker", "BROKER" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Affiliation" },
                values: new object[,]
                {
                    { (short)1, "Scrumbags" },
                    { (short)2, "KelleSolutions" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_Team",
                table: "People",
                column: "Team");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Teams_Team",
                table: "People",
                column: "Team",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Teams_Team",
                table: "People");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_People_Team",
                table: "People");

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
    }
}
