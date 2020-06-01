using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class R : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ab9a7f6-ab78-4656-82f7-311f429cd537");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38ca41ac-4497-4687-a2be-2136bcd98fca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "763fd667-1738-4ba2-9cfe-ef52a3e1acd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82baf83e-e772-4ce6-91b8-5a02b9803331");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb1d83fb-72f5-45e5-94e6-971ec12c7968");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "248be17f-a222-4b6e-a05f-543c1fc7705e", "f00b1fa1-c29b-411e-ab60-32c17b6032c6", "ClubManager", "CLUBMANAGER" },
                    { "a2e14ac1-11e2-4d8e-9544-22d2ea4e453b", "82b90c1a-df2c-4867-8944-9ab9638171cc", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "9c1ac471-bf4a-46d3-a55e-adfc3972cb3d", "e148b807-6b9e-4f29-8976-bddf81ca3836", "GymManager", "GYMMANAGER" },
                    { "050a2772-4bdf-4e17-a325-4b6be49f4083", "99524343-9a60-4335-9ac0-1372fee79799", "Coach", "COACH" },
                    { "6750d73b-d099-4ee0-9887-8ec0e83b6d0d", "98273e96-7b46-4394-87b7-cfa410ada619", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "050a2772-4bdf-4e17-a325-4b6be49f4083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "248be17f-a222-4b6e-a05f-543c1fc7705e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6750d73b-d099-4ee0-9887-8ec0e83b6d0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c1ac471-bf4a-46d3-a55e-adfc3972cb3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2e14ac1-11e2-4d8e-9544-22d2ea4e453b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eb1d83fb-72f5-45e5-94e6-971ec12c7968", "3fd3449a-4dbf-459f-b0a4-815ef7dad754", "ClubManager", "CLUBMANAGER" },
                    { "38ca41ac-4497-4687-a2be-2136bcd98fca", "f7d18dae-78e6-44d5-98a5-7e46de065aad", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "82baf83e-e772-4ce6-91b8-5a02b9803331", "317ce923-21db-402a-ac07-0fa6f58f0b2a", "GymManager", "GYMMANAGER" },
                    { "763fd667-1738-4ba2-9cfe-ef52a3e1acd4", "d121c7f1-4f4a-43b7-83e7-5a3853f63955", "Coach", "COACH" },
                    { "2ab9a7f6-ab78-4656-82f7-311f429cd537", "3a9b16e8-0da0-4a76-a259-1eb81fba53d2", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
