using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Data.Migrations
{
    public partial class seedingroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d952a4e-584b-485e-b16c-6b34f414b9af", "bcbfc403-fcac-428d-aa5c-be91c0726895", "ClubManager", "CLUBMANAGER" },
                    { "3b17f803-a076-41f9-919a-577fd57d9d78", "399b2c43-c555-4518-9c99-73abf0749851", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "648f200c-f647-4545-89e6-1cc74139ab41", "0bee5b72-8108-47f5-aa76-8c8b973ac6f0", "GymManager", "GYMMANAGER" },
                    { "1ae46a30-13e9-4062-b36c-0b9e7bc3751a", "20d88051-065c-483a-9d06-079ae39b9273", "Coach", "COACH" },
                    { "9296ee86-6920-4fc0-84a1-a5bc46a11aad", "3c9c3684-2fbc-4671-9923-db35d7e246c2", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae46a30-13e9-4062-b36c-0b9e7bc3751a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b17f803-a076-41f9-919a-577fd57d9d78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d952a4e-584b-485e-b16c-6b34f414b9af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "648f200c-f647-4545-89e6-1cc74139ab41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9296ee86-6920-4fc0-84a1-a5bc46a11aad");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
