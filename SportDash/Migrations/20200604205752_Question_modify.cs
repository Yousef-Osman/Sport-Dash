using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class Question_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f116479-56ad-402d-bc9b-f47b43510e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ff4269e-2232-4c78-8597-9e2bd072cd24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59a925d3-4bd0-4b9c-9314-9dc990dcc436");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b416c13b-4b04-4c36-92ce-2b6416d142e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa14a6fe-9e38-4ac9-aac2-cf077d96adf7");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "TargetId",
                table: "Questions",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fef69dca-c8e0-4a07-9361-abc3e9afdddd", "433bd65d-0dee-4876-bb5b-eaaf48f6079e", "ClubManager", "CLUBMANAGER" },
                    { "6b7c4007-1910-4bd4-ab58-d62f07123152", "73ac6235-059a-45f1-b378-37c28cb9dffc", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "095ef5a6-b345-4c8d-abe2-8e72f2e862c1", "4aaeffc3-3529-4c05-82ea-45db768534c0", "GymManager", "GYMMANAGER" },
                    { "0d16cbbf-c8ae-467e-a890-91bd816390a1", "682541f1-918b-4d7d-8abe-c28a8ecc89f4", "Coach", "COACH" },
                    { "bd341358-953f-4878-9358-889beefd2c43", "1c3edbe8-0d3b-4dbf-b066-10851d2bf834", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TargetId",
                table: "Questions",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_TargetId",
                table: "Questions",
                column: "TargetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_TargetId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TargetId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "095ef5a6-b345-4c8d-abe2-8e72f2e862c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d16cbbf-c8ae-467e-a890-91bd816390a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b7c4007-1910-4bd4-ab58-d62f07123152");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd341358-953f-4878-9358-889beefd2c43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fef69dca-c8e0-4a07-9361-abc3e9afdddd");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fa14a6fe-9e38-4ac9-aac2-cf077d96adf7", "dbe4578e-3dec-4eea-a806-e43342e92502", "ClubManager", "CLUBMANAGER" },
                    { "4f116479-56ad-402d-bc9b-f47b43510e03", "2d104fdc-f4dc-4fcf-96a9-91d1531ad920", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "b416c13b-4b04-4c36-92ce-2b6416d142e8", "957762a3-266b-49a9-975c-063ae46258f4", "GymManager", "GYMMANAGER" },
                    { "4ff4269e-2232-4c78-8597-9e2bd072cd24", "dbe5958d-1ba9-40c0-8a0f-031341959d0a", "Coach", "COACH" },
                    { "59a925d3-4bd0-4b9c-9314-9dc990dcc436", "80fb1e9b-d570-4083-a1db-76e01e7f3999", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
