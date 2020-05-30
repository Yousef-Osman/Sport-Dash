using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class addedRoleNamePropToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27385aff-5a6f-4d68-a682-ae9a9c9bea1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b5bf132-9a4b-4fe9-8663-f53caa6bd23c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdba519f-2a70-47b5-8d74-524437d61b12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d735127e-dad0-4f89-b3c5-a1267ac4cf21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8e86f47-bba0-45a1-baf9-8159b085a148");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "RoleName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8e86f47-bba0-45a1-baf9-8159b085a148", "1f917e9c-82c2-4b7a-9b89-514e5e5b9405", "ClubManager", "CLUBMANAGER" },
                    { "d735127e-dad0-4f89-b3c5-a1267ac4cf21", "81bb697e-2644-4723-af08-c9083e379b68", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "5b5bf132-9a4b-4fe9-8663-f53caa6bd23c", "2e86b059-d579-412c-9ce1-df037a55d3ad", "GymManager", "GYMMANAGER" },
                    { "27385aff-5a6f-4d68-a682-ae9a9c9bea1a", "f6861d94-689c-4914-9897-d70a0875654f", "Coach", "COACH" },
                    { "cdba519f-2a70-47b5-8d74-524437d61b12", "14df1192-500e-406b-975d-957812ca8252", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
