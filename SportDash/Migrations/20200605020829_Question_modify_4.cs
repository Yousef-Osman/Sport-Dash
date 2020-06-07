using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class Question_modify_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0da4be14-c7fa-421e-837d-1a9d4669fc39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "681feb97-29e4-488d-b8ea-78365814a787");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d64513c-e741-4618-898c-1b68b3ae58a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be9bd121-f5ed-4802-a4fa-a54e96ab06aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdd9f40f-3a61-4012-96e4-1feea47a122d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5025b201-e996-4a03-961a-6090b107c847", "03cc931d-ace0-4601-952a-eefc2d1f8513", "ClubManager", "CLUBMANAGER" },
                    { "08cafd17-5d24-4b46-b1e6-c66a0d4290a9", "72566b48-0339-4e49-8641-e124798883c4", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "76f238cf-b3b6-4b60-aed4-6c75e95706ed", "63f39286-d6ff-4ea7-9588-6951ae3ff4e6", "GymManager", "GYMMANAGER" },
                    { "851d3648-c006-4fbc-a98a-0351e4cc62a7", "cc33edcc-f0af-4c9b-a1ad-d370ac892f4f", "Coach", "COACH" },
                    { "c1310a40-df7b-44af-8624-8c49650fa2af", "884e2d15-6145-4689-8094-9b5e879cc09d", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08cafd17-5d24-4b46-b1e6-c66a0d4290a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5025b201-e996-4a03-961a-6090b107c847");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f238cf-b3b6-4b60-aed4-6c75e95706ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "851d3648-c006-4fbc-a98a-0351e4cc62a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1310a40-df7b-44af-8624-8c49650fa2af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "681feb97-29e4-488d-b8ea-78365814a787", "c9653634-8b3a-4aa9-85b2-fbb200cfeffb", "ClubManager", "CLUBMANAGER" },
                    { "be9bd121-f5ed-4802-a4fa-a54e96ab06aa", "3c18344a-f22e-449d-b603-9ae01005db47", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "8d64513c-e741-4618-898c-1b68b3ae58a8", "eb3e1f10-e942-4022-a904-4f60bd5c7d88", "GymManager", "GYMMANAGER" },
                    { "fdd9f40f-3a61-4012-96e4-1feea47a122d", "73292772-b832-4cec-936e-2249a8ccfcf2", "Coach", "COACH" },
                    { "0da4be14-c7fa-421e-837d-1a9d4669fc39", "de5a424a-7a5c-4b84-bfcc-384624d54ad5", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
