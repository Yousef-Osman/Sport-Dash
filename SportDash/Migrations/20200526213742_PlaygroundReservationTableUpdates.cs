using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class PlaygroundReservationTableUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_playgroundReservations",
                table: "playgroundReservations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c46daf6-9483-47cc-abdc-769521e7c133");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a73a0f5-7b10-4b74-9930-ab7b1aee16ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af8ade6-0053-4d76-b51b-126c351bd667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abe31908-e47a-4fb3-8768-9b112bd60c45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4a787d9-9f29-427d-83f5-7c36bf1f6fae");

            migrationBuilder.DropColumn(
                name: "PlaygroundReservationId",
                table: "playgroundReservations");

            migrationBuilder.DropColumn(
                name: "IsOccubied",
                table: "playgroundReservations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "playgroundReservations",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "playgroundReservations",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "playgroundReservations",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "playgroundReservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "playgroundReservations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_playgroundReservations",
                table: "playgroundReservations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c335502a-88fe-49b0-b3e7-e0cb4d31bca6", "dee481a4-5cdd-49ac-8847-2405432865ce", "ClubManager", "CLUBMANAGER" },
                    { "00f5638b-47b8-4016-9c55-97f8f34d7fc3", "56f80132-d17a-458f-b09f-e351f0f9f06f", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "fd803903-f9e8-4dee-95b5-6cbc100473b1", "b485c80c-a145-44d2-9a43-04581a020af0", "GymManager", "GYMMANAGER" },
                    { "c0ee6960-95d5-4c4a-a319-a0b68c6e7ee5", "d5c8730b-f27f-4318-83e0-ab2b5f3805f2", "Coach", "COACH" },
                    { "b72cf9ee-da31-429e-8a34-455bb07a08f6", "f57f0c29-d0ee-48f5-885a-51c5682c0e25", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_playgroundReservations_UserId",
                table: "playgroundReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_playgroundReservations_AspNetUsers_UserId",
                table: "playgroundReservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playgroundReservations_AspNetUsers_UserId",
                table: "playgroundReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playgroundReservations",
                table: "playgroundReservations");

            migrationBuilder.DropIndex(
                name: "IX_playgroundReservations_UserId",
                table: "playgroundReservations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f5638b-47b8-4016-9c55-97f8f34d7fc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b72cf9ee-da31-429e-8a34-455bb07a08f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ee6960-95d5-4c4a-a319-a0b68c6e7ee5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c335502a-88fe-49b0-b3e7-e0cb4d31bca6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd803903-f9e8-4dee-95b5-6cbc100473b1");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "playgroundReservations");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "playgroundReservations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "playgroundReservations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "playgroundReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "playgroundReservations");

            migrationBuilder.AddColumn<string>(
                name: "PlaygroundReservationId",
                table: "playgroundReservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccubied",
                table: "playgroundReservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_playgroundReservations",
                table: "playgroundReservations",
                column: "PlaygroundReservationId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a73a0f5-7b10-4b74-9930-ab7b1aee16ec", "81ee5c2c-fa88-433f-9d64-cc05006bb3b7", "ClubManager", "CLUBMANAGER" },
                    { "abe31908-e47a-4fb3-8768-9b112bd60c45", "e898c6e6-7311-41a0-8c63-b9f5dade7db2", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "9af8ade6-0053-4d76-b51b-126c351bd667", "af6af67f-52a5-48c1-a27a-f8a8a9c715bb", "GymManager", "GYMMANAGER" },
                    { "2c46daf6-9483-47cc-abdc-769521e7c133", "2b8e2b2c-d381-4ed6-bfc1-e335cd4f53f6", "Coach", "COACH" },
                    { "e4a787d9-9f29-427d-83f5-7c36bf1f6fae", "17b9d139-5e3b-4516-a926-a29740c1954a", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
