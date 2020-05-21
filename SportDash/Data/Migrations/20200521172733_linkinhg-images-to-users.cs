using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Data.Migrations
{
    public partial class linkinhgimagestousers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Images",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac134b06-b307-49f8-9fc9-f10e5e2c7a20", "bb704452-d1f8-4ce2-bdfe-bf461381021e", "ClubManager", "CLUBMANAGER" },
                    { "3f8b9251-d8cc-4a18-8cf3-d20097df263a", "1bc5538e-a455-4391-90a2-82b88c2c8ea9", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "c50c3dec-57c2-4db3-8b11-44e985627308", "55ea1fca-c30e-4e73-89ca-d2e50fa2f959", "GymManager", "GYMMANAGER" },
                    { "0b3969d5-39cb-4b58-bb33-7be02104aba5", "63450a4a-7305-4cd4-9920-99558c19e124", "Coach", "COACH" },
                    { "73e56cb5-832e-44fc-8730-0d71c1980b63", "88b66d81-0927-4128-9dad-ad6e8a27ee44", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ApplicationUserId",
                table: "Images",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_ApplicationUserId",
                table: "Images",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_ApplicationUserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ApplicationUserId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b3969d5-39cb-4b58-bb33-7be02104aba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8b9251-d8cc-4a18-8cf3-d20097df263a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e56cb5-832e-44fc-8730-0d71c1980b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac134b06-b307-49f8-9fc9-f10e5e2c7a20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c50c3dec-57c2-4db3-8b11-44e985627308");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

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
    }
}
