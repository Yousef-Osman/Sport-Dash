using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Data.Migrations
{
    public partial class addedTrainingProgramsAndGymPricesModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymId = table.Column<string>(nullable: true),
                    Subscribtion_Price = table.Column<double>(nullable: false),
                    Subscribtion_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPrices_AspNetUsers_GymId",
                        column: x => x.GymId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TrainingDate = table.Column<DateTime>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Trainer_Name = table.Column<string>(nullable: false),
                    ForLadies = table.Column<bool>(nullable: false),
                    ClubId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_AspNetUsers_ClubId",
                        column: x => x.ClubId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymPrices_GymId",
                table: "GymPrices",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_ClubId",
                table: "TrainingPrograms",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymPrices");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");
        }
    }
}
