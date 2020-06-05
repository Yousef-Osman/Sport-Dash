using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class addedHasNewMsgsPropInAppUserAndIsProfImgInImage : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "IsProfileImg",
                table: "Images",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasNewMsgs",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ada70f33-9989-4022-98a9-ea9fd9216814", "22a37426-08c8-45e8-9c1b-707a64bf736d", "ClubManager", "CLUBMANAGER" },
                    { "5b55a06e-0e69-4c00-adc3-70ff90219a50", "9ff05fdd-361f-4acc-9c38-6209c2ae634a", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "e64ccb31-abfc-4ca2-bbfd-9c5322810821", "95615b69-329f-4418-ac16-e98ce90ecc7b", "GymManager", "GYMMANAGER" },
                    { "c6f3692d-2caa-4b25-a1d0-2c5d34949fcf", "f8d64b3d-cc8c-4c37-8e2f-c2529ce3de71", "Coach", "COACH" },
                    { "fa29aec8-8dce-46bf-aeb3-3b2428c1e325", "830f818d-ef3c-4b39-9b8a-94642ae031d4", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b55a06e-0e69-4c00-adc3-70ff90219a50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada70f33-9989-4022-98a9-ea9fd9216814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f3692d-2caa-4b25-a1d0-2c5d34949fcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64ccb31-abfc-4ca2-bbfd-9c5322810821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa29aec8-8dce-46bf-aeb3-3b2428c1e325");

            migrationBuilder.DropColumn(
                name: "IsProfileImg",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "HasNewMsgs",
                table: "AspNetUsers");

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
