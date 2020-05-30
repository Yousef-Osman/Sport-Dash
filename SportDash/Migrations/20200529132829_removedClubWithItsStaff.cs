using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class removedClubWithItsStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ClubId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClubId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e53f085-9a32-423d-99e9-e08ef090d6b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b67c87f-1bb8-451e-a9b1-963b8acdf4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f8c0d60-a8c4-496b-8526-0e3b54e0c5fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb861de8-c242-46c5-b6d4-b36ef414a858");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e561113a-3d22-4b20-93e2-041aa40ed303");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ClubId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e53f085-9a32-423d-99e9-e08ef090d6b8", "050980bd-38c5-4882-95b2-6eeff0f815f0", "ClubManager", "CLUBMANAGER" },
                    { "e561113a-3d22-4b20-93e2-041aa40ed303", "ee40a1f4-6eaa-4140-ac5f-6d791c8262db", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "9f8c0d60-a8c4-496b-8526-0e3b54e0c5fc", "ea7f74de-751a-49d5-87d3-a368dbe5f6a6", "GymManager", "GYMMANAGER" },
                    { "9b67c87f-1bb8-451e-a9b1-963b8acdf4fa", "a5394950-43e7-40bf-bf7b-ee6d891b462b", "Coach", "COACH" },
                    { "cb861de8-c242-46c5-b6d4-b36ef414a858", "cbad6309-8cd4-415e-8a53-9742eb486d3e", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClubId",
                table: "AspNetUsers",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ClubId",
                table: "AspNetUsers",
                column: "ClubId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
