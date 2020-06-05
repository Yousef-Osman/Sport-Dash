using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class madeSomePropsInAppUserNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "Toilet",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Safe",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "LockerRoom",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ForLadies",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "BallRenting",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47b93c74-02a1-4efa-be5f-15091c757d6d", "bf8c808f-2e2d-45d4-852f-ea86a9fef3a0", "ClubManager", "CLUBMANAGER" },
                    { "d8ab510d-ccec-458b-8747-e75ae9fa7084", "87d65dbe-9c48-4927-8e96-4bfff80ad893", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "da34e735-4787-4ded-9e13-5ee9b946cb0a", "feec743e-030c-41fb-b638-279b0322b49c", "GymManager", "GYMMANAGER" },
                    { "dc9aaa40-4e58-4429-9a44-50d859ba12fa", "8c29e3c2-1f89-4cb7-8cea-73dfd2a7ef96", "Coach", "COACH" },
                    { "e8299fc7-25f1-4774-832b-02e5b710cc97", "5eefa54b-6083-470a-8fad-1114d6a28de6", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47b93c74-02a1-4efa-be5f-15091c757d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ab510d-ccec-458b-8747-e75ae9fa7084");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da34e735-4787-4ded-9e13-5ee9b946cb0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc9aaa40-4e58-4429-9a44-50d859ba12fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8299fc7-25f1-4774-832b-02e5b710cc97");

            migrationBuilder.AlterColumn<bool>(
                name: "Toilet",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Safe",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LockerRoom",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ForLadies",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BallRenting",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

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
    }
}
