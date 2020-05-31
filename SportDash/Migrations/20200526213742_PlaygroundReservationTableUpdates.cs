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
        }
    }
}
