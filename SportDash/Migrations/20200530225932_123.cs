using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ab50e26-b5ad-4bde-851d-c6e1bd79fc5b", "6d0cf39a-19dd-4c47-b275-8e48c313165d", "ClubManager", "CLUBMANAGER" },
                    { "1101c171-8527-448b-8bbe-e8e3b7d26f8d", "dc10c5f0-662b-473f-acf0-6d50f9d6a53c", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "f13d192c-ac98-4233-8c87-506413cfbefe", "abbb5649-42f7-437a-97e1-92a1f45a54d5", "GymManager", "GYMMANAGER" },
                    { "dea9f39d-5c9f-4882-a490-44b03c7c4ac1", "236a614f-f6cc-4721-99ab-e5f841a1f823", "Coach", "COACH" },
                    { "19782a02-d265-413a-9c8e-b7368949dfcc", "1739b844-bed8-4e5f-9b87-f8ec7f4762d7", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1101c171-8527-448b-8bbe-e8e3b7d26f8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19782a02-d265-413a-9c8e-b7368949dfcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ab50e26-b5ad-4bde-851d-c6e1bd79fc5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea9f39d-5c9f-4882-a490-44b03c7c4ac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f13d192c-ac98-4233-8c87-506413cfbefe");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Category",
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
    }
}
