using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class addcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0beb3e2e-276e-4049-a835-812214958d68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "729ac482-25fa-499c-97b5-3133a92986c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96462a58-5e3d-4f93-97f9-658fd0a022f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4ac22d9-06c9-46e5-bd5d-dce96d8891a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd583ff9-b116-4ef6-94f2-b2b44e3cbe90");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03cb44c9-ef5b-4a9b-a95a-0c210440502d", "59382a6d-70be-4acf-9a1b-54996a5c9475", "ClubManager", "CLUBMANAGER" },
                    { "64d0a784-b499-496a-86db-1c52775c3c6c", "df3edcf7-0163-4432-8386-97997a768517", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "50a28032-8568-4c25-8b23-d74f7a066905", "3088c265-f1f3-4b01-817f-8a6ff9cdda42", "GymManager", "GYMMANAGER" },
                    { "6a800145-e73f-471c-b595-ba95e0c86ec0", "95469846-f38a-4cc1-a01b-1fb295bcfe9d", "Coach", "COACH" },
                    { "2b2a4ac1-4cd7-4458-96a2-344d2a256dfe", "5d76ba7c-39cb-41f7-8b25-9312794120e3", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03cb44c9-ef5b-4a9b-a95a-0c210440502d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b2a4ac1-4cd7-4458-96a2-344d2a256dfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50a28032-8568-4c25-8b23-d74f7a066905");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64d0a784-b499-496a-86db-1c52775c3c6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a800145-e73f-471c-b595-ba95e0c86ec0");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fd583ff9-b116-4ef6-94f2-b2b44e3cbe90", "717c0fa7-e01c-4063-b486-3ab85d4652ec", "ClubManager", "CLUBMANAGER" },
                    { "729ac482-25fa-499c-97b5-3133a92986c7", "f91ddf78-3264-44e4-a8ea-00f3397460cd", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "96462a58-5e3d-4f93-97f9-658fd0a022f4", "8621c9ef-4ffb-4525-a0e9-eabdb70211e1", "GymManager", "GYMMANAGER" },
                    { "0beb3e2e-276e-4049-a835-812214958d68", "d510ba8f-087e-4b28-a310-08bc6e3c11de", "Coach", "COACH" },
                    { "f4ac22d9-06c9-46e5-bd5d-dce96d8891a6", "8e4f1ac4-0fbe-445a-bafa-0fe2407a6291", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
