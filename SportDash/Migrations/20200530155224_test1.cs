using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playgroundPrices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79cc4e42-b395-4398-8f9b-92fbbb520fe3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3ddb406-9804-4560-ae26-8e649e0f7c86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b415ee2e-a7df-40a3-958f-f810333a0c56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb47b4d0-13f6-4e09-903f-48324b52b4f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f01fc5ec-93cc-4d2f-84c0-c2ea92aead77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86b57d41-1e89-4abd-b2a8-d13378f59090", "fe498d6f-a263-45fc-8c86-752fd45d3e28", "ClubManager", "CLUBMANAGER" },
                    { "db80304f-366e-4b79-9597-72f13f2911af", "790b6416-db18-4895-872d-15e5ebdc728e", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "366fa452-be04-43c1-9b8b-ca5bc66f11d6", "760baf56-2a90-44ad-ba9d-ec3020170fad", "GymManager", "GYMMANAGER" },
                    { "c3fa8a45-97ca-4562-9bec-c1b9107c2d17", "e93ba737-ef9d-41f3-9abd-cfa6e5263ded", "Coach", "COACH" },
                    { "4fe44d3e-f220-49eb-a230-2754f141fd77", "d4cf7309-8c90-4d62-905d-6dc6929c7700", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366fa452-be04-43c1-9b8b-ca5bc66f11d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe44d3e-f220-49eb-a230-2754f141fd77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b57d41-1e89-4abd-b2a8-d13378f59090");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3fa8a45-97ca-4562-9bec-c1b9107c2d17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db80304f-366e-4b79-9597-72f13f2911af");

            migrationBuilder.CreateTable(
                name: "playgroundPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    End = table.Column<TimeSpan>(type: "time", nullable: false),
                    PlaygroundId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playgroundPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playgroundPrices_AspNetUsers_PlaygroundId",
                        column: x => x.PlaygroundId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f01fc5ec-93cc-4d2f-84c0-c2ea92aead77", "8abec7d2-022d-4464-ac15-381cbcd50244", "ClubManager", "CLUBMANAGER" },
                    { "eb47b4d0-13f6-4e09-903f-48324b52b4f9", "cdccc2e1-9b72-4c38-b042-cf1ba92914bc", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "a3ddb406-9804-4560-ae26-8e649e0f7c86", "7d8ba257-fb07-43dc-b2c9-f9c9dc23d4ec", "GymManager", "GYMMANAGER" },
                    { "b415ee2e-a7df-40a3-958f-f810333a0c56", "ff59c2a9-1b55-4bfa-8da2-81fcf6d2fbc6", "Coach", "COACH" },
                    { "79cc4e42-b395-4398-8f9b-92fbbb520fe3", "6d799dc0-51c5-47f8-9bca-9a455be4aecb", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_playgroundPrices_PlaygroundId",
                table: "playgroundPrices",
                column: "PlaygroundId");
        }
    }
}
