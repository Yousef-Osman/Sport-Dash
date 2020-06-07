using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class Question_modify_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Category",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "TargetId",
                table: "Questions",
                type: "nvarchar(450)",
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
    }
}
