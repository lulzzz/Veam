using Microsoft.EntityFrameworkCore.Migrations;

namespace Veam.EAM.Data.Migrations
{
    public partial class gg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "EAM",
                table: "AssetStatus",
                columns: new[] { "Id", "status" },
                values: new object[,]
                {
                    { 1, "InStock" },
                    { 2, "Assigned" },
                    { 3, "InMaintenance" },
                    { 4, "Archived" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "EAM",
                table: "AssetStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "EAM",
                table: "AssetStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "EAM",
                table: "AssetStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "EAM",
                table: "AssetStatus",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
