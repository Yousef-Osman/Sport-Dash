using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Data.Migrations
{
    public partial class adding_ramy_enities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playgroundPrices",
                columns: table => new
                {
                    PlaygroundId = table.Column<string>(nullable: false),
                    Start = table.Column<TimeSpan>(nullable: false),
                    End = table.Column<TimeSpan>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playgroundPrices", x => new { x.PlaygroundId, x.Start, x.End });
                    table.ForeignKey(
                        name: "FK_playgroundPrices_AspNetUsers_PlaygroundId",
                        column: x => x.PlaygroundId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playgroundReservations",
                columns: table => new
                {
                    PlaygroundReservationId = table.Column<string>(nullable: false),
                    PlaygroundId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsOccubied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playgroundReservations", x => x.PlaygroundReservationId);
                    table.ForeignKey(
                        name: "FK_playgroundReservations_AspNetUsers_PlaygroundId",
                        column: x => x.PlaygroundId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_playgroundReservations_PlaygroundId",
                table: "playgroundReservations",
                column: "PlaygroundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playgroundPrices");

            migrationBuilder.DropTable(
                name: "playgroundReservations");
        }
    }
}
