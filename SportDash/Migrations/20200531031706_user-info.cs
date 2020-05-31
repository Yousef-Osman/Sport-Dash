using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class userinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09265aa1-3ccc-466c-b969-46021c929eac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f405d76-9a9a-4565-8cbd-ed4485bd01df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4a16da7-5f0c-40b4-b97c-4c1523e5410c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d58a04d4-6492-4264-b1ff-8db089f6f88b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea763756-0bf9-4973-ae45-c11b5b6719cb");

            migrationBuilder.AddColumn<bool>(
                name: "BallRenting",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ForLadies",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockerRoom",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Safe",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Toilet",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BallRenting",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForLadies",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockerRoom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Safe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Toilet",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f405d76-9a9a-4565-8cbd-ed4485bd01df", "4944baff-0234-4575-aaf5-8f835aa8ae8f", "ClubManager", "CLUBMANAGER" },
                    { "d58a04d4-6492-4264-b1ff-8db089f6f88b", "4aa4904c-a997-4e7a-b586-6692aec5c24c", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "09265aa1-3ccc-466c-b969-46021c929eac", "616f24a6-6971-457b-a221-a88c20cf531e", "GymManager", "GYMMANAGER" },
                    { "ea763756-0bf9-4973-ae45-c11b5b6719cb", "259f8243-47bd-4f7d-a2af-b75c9a59bfec", "Coach", "COACH" },
                    { "a4a16da7-5f0c-40b4-b97c-4c1523e5410c", "a9205d02-6525-422e-a38b-a28ee9fb9f69", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
