using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class adding_playground_price_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaygroundId = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Start = table.Column<TimeSpan>(nullable: false),
                    End = table.Column<TimeSpan>(nullable: false)
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
                    { "6079d299-299e-4584-b647-8f35091e7916", "c823bf29-163d-4187-88d7-b4cdfba73ba0", "ClubManager", "CLUBMANAGER" },
                    { "b3b90adc-a66a-4113-9786-770da6812849", "33b273f4-63c4-4af2-bb01-42f2953098e3", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "c6c3481b-500e-43d8-accf-e4e12beaa473", "c18b18fb-4d65-4656-838b-0d12da6d2e81", "GymManager", "GYMMANAGER" },
                    { "66fd5601-8406-4165-8858-8f6ab6dc6d70", "2be92494-0034-458b-9fe7-b57382f9afff", "Coach", "COACH" },
                    { "7001820c-9833-4d09-8b80-f59eea7ee3b1", "88a83b78-308c-42fe-8456-6bd2927efc85", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_playgroundPrices_PlaygroundId",
                table: "playgroundPrices",
                column: "PlaygroundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playgroundPrices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6079d299-299e-4584-b647-8f35091e7916");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66fd5601-8406-4165-8858-8f6ab6dc6d70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7001820c-9833-4d09-8b80-f59eea7ee3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3b90adc-a66a-4113-9786-770da6812849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6c3481b-500e-43d8-accf-e4e12beaa473");

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
    }
}
