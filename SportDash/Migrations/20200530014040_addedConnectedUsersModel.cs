using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class addedConnectedUsersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ec5f45d-214c-4ccf-8727-0a7f4b95ed3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "153ccfbe-96b0-419d-84dc-50d881495c4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee32c63-e97e-42e0-ae95-a9a4619a6fd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a60b1ed7-6933-4e9c-a822-58de8a71be5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4ca9f60-81d7-43d2-81ab-a4fc7ba88ae1");

            migrationBuilder.CreateTable(
                name: "ConnectedUsers",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedUsers", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_ConnectedUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff2b793f-cd27-4a3b-96a7-7f18616007d0", "393ca449-1cc0-4bc3-9e5b-0bffe7069c33", "ClubManager", "CLUBMANAGER" },
                    { "9b9b84c6-f0d6-4b57-a463-e855278ede33", "40bf3741-b9d5-4a8e-956a-47e0dc9e81e7", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "8814411a-7d2a-4395-bbcf-597f7f5e7323", "7015683b-1aa4-4c38-84a3-c42c514cfdb1", "GymManager", "GYMMANAGER" },
                    { "9930a63c-9c9b-4b9e-bef6-cc240b6c25f1", "9a5890b4-dbe2-4e4e-8077-e82c3a285c4d", "Coach", "COACH" },
                    { "820161ec-352d-4168-91fb-018a0bc0031a", "5e8f964e-7d65-40ed-87ce-e6e78f842b9a", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedUsers_UserId",
                table: "ConnectedUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectedUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "820161ec-352d-4168-91fb-018a0bc0031a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8814411a-7d2a-4395-bbcf-597f7f5e7323");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9930a63c-9c9b-4b9e-bef6-cc240b6c25f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b9b84c6-f0d6-4b57-a463-e855278ede33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff2b793f-cd27-4a3b-96a7-7f18616007d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ee32c63-e97e-42e0-ae95-a9a4619a6fd4", "650783dd-fea1-4379-9012-5946516dfc59", "ClubManager", "CLUBMANAGER" },
                    { "0ec5f45d-214c-4ccf-8727-0a7f4b95ed3c", "04b76a34-da78-4ddb-aa83-9b8212e880f7", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "153ccfbe-96b0-419d-84dc-50d881495c4f", "36809ab3-2045-4c49-9d59-d1cc8f631f1f", "GymManager", "GYMMANAGER" },
                    { "a60b1ed7-6933-4e9c-a822-58de8a71be5b", "d42537ad-a7db-4a41-9030-59beac7b652e", "Coach", "COACH" },
                    { "b4ca9f60-81d7-43d2-81ab-a4fc7ba88ae1", "ba3ac75d-7455-44a3-8299-8439ee88b752", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
