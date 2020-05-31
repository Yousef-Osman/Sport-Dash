using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class Add_Id_to_PlaygroundPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cac772a-602f-4f72-9727-47f575711d2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c01eb3c-07fb-4dcf-a048-67935169f69b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8437fd35-783c-4830-b523-db89928c86ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96312b23-1288-4055-a036-c64addef9f45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0399e29-2f02-4323-baf8-f5137123152d");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "0cac772a-602f-4f72-9727-47f575711d2f", "2a2a6e93-8758-459a-9ddc-360908d8f1ad", "ClubManager", "CLUBMANAGER" },
                    { "e0399e29-2f02-4323-baf8-f5137123152d", "b23affcf-6be3-40e4-95d3-417a80dd4088", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "7c01eb3c-07fb-4dcf-a048-67935169f69b", "4935a3b1-27fe-4827-8797-46bf5efb7fd1", "GymManager", "GYMMANAGER" },
                    { "96312b23-1288-4055-a036-c64addef9f45", "e6881093-ba42-4cb0-bf6d-99e60050a6c8", "Coach", "COACH" },
                    { "8437fd35-783c-4830-b523-db89928c86ba", "362e0828-55dc-464f-9093-3857e369e777", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
