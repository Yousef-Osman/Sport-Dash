using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class R2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "d73d7975-bdd4-4c8c-a9e0-1d3134030413", "7ab90236-53d8-4543-83d0-55b52ee5006f", "ClubManager", "CLUBMANAGER" },
                    { "1b0d3b70-c05c-4622-b97e-a6a42cf29a2e", "90bc7a09-3e0d-4719-a534-e57576d68a68", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "ba8e9f2a-4920-4180-af26-2665bbcaab0d", "6be883ec-40b5-49d1-b337-ece2e2eed74a", "GymManager", "GYMMANAGER" },
                    { "66bb4633-4415-4bd2-908d-d241460e5f2b", "99943c03-d1f8-4840-b679-aa11fc9450da", "Coach", "COACH" },
                    { "8d75a498-0182-4599-91d9-42e0a7d27416", "419f4de5-5f72-4a2a-8504-8cbcc1883ad2", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b0d3b70-c05c-4622-b97e-a6a42cf29a2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66bb4633-4415-4bd2-908d-d241460e5f2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d75a498-0182-4599-91d9-42e0a7d27416");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba8e9f2a-4920-4180-af26-2665bbcaab0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d73d7975-bdd4-4c8c-a9e0-1d3134030413");

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
    }
}
