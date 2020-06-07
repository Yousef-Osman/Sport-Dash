using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class Question_modify_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d7c0e1-d7f1-417a-bc3d-1c7de02115e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42912329-ffbf-40de-9e36-2af40ae269c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4331576b-68ce-459d-9051-f66d2df26348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de4fac3c-cf75-4663-bd8f-f059b8c9d3f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0d32409-cb0d-4985-93cb-f7f08c0cd258");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Questions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LastUpdateTime",
                table: "Questions");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42912329-ffbf-40de-9e36-2af40ae269c4", "9f281797-6707-40ed-ac73-df56001e257e", "ClubManager", "CLUBMANAGER" },
                    { "de4fac3c-cf75-4663-bd8f-f059b8c9d3f1", "e781a6af-6537-40c8-ac71-a0f94b79b84e", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "e0d32409-cb0d-4985-93cb-f7f08c0cd258", "ee91a77b-b134-4a0b-9622-915ef26e90a0", "GymManager", "GYMMANAGER" },
                    { "4331576b-68ce-459d-9051-f66d2df26348", "a3e6a00f-22e2-46c4-9b68-e355d7955ee2", "Coach", "COACH" },
                    { "26d7c0e1-d7f1-417a-bc3d-1c7de02115e6", "a38646cd-71b0-45c8-8414-404631598488", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
