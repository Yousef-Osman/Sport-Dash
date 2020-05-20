using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Data.Migrations
{
    public partial class MessageReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Message_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender_Id = table.Column<string>(nullable: true),
                    Receiver_Id = table.Column<string>(nullable: true),
                    Message_Date = table.Column<DateTime>(nullable: false),
                    Message_Body = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Message_Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_Receiver_Id",
                        column: x => x.Receiver_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_Sender_Id",
                        column: x => x.Sender_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Review_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reviewer_Id = table.Column<string>(nullable: true),
                    Reviewee_Id = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Review_Date = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_Reviewee_Id",
                        column: x => x.Reviewee_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_Reviewer_Id",
                        column: x => x.Reviewer_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Receiver_Id",
                table: "Messages",
                column: "Receiver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Sender_Id",
                table: "Messages",
                column: "Sender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Reviewee_Id",
                table: "Reviews",
                column: "Reviewee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Reviewer_Id",
                table: "Reviews",
                column: "Reviewer_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
