using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class gym_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6079d299-299e-4584-b647-8f35091e7916");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66fd5601-8406-4165-8858-8f6ab6dc6d70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7001820c-9833-4d09-8b80-f59eea7ee3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3b90adc-a66a-4113-9786-770da6812849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6c3481b-500e-43d8-accf-e4e12beaa473");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e0094b3f-718d-4fb3-889b-71c1cce46f08", "dfa62763-9f40-40b8-92e3-75f2f08e2d29", "ClubManager", "CLUBMANAGER" },
                    { "5370b09a-993f-4a03-867e-71dd08a61b17", "c8c7b0cd-b99c-49f1-ae45-6c66056075ce", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "9a579876-8c1d-4452-82ce-817ed7e17b08", "2ce5dfee-c578-4313-b573-b7bef83ad015", "GymManager", "GYMMANAGER" },
                    { "10a3ba70-cbda-4ff0-9dda-86a0367b1728", "f95b8710-f081-4ced-85a4-0526fc7c49a0", "Coach", "COACH" },
                    { "5e284766-40f5-411b-84df-486084457ef6", "ddf03785-3c61-4b6f-a79c-58eaf0f97d84", "NormalUser", "NORMALUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10a3ba70-cbda-4ff0-9dda-86a0367b1728");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5370b09a-993f-4a03-867e-71dd08a61b17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e284766-40f5-411b-84df-486084457ef6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a579876-8c1d-4452-82ce-817ed7e17b08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0094b3f-718d-4fb3-889b-71c1cce46f08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6079d299-299e-4584-b647-8f35091e7916", "c823bf29-163d-4187-88d7-b4cdfba73ba0", "ClubManager", "CLUBMANAGER" },
                    { "b3b90adc-a66a-4113-9786-770da6812849", "33b273f4-63c4-4af2-bb01-42f2953098e3", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "c6c3481b-500e-43d8-accf-e4e12beaa473", "c18b18fb-4d65-4656-838b-0d12da6d2e81", "GymManager", "GYMMANAGER" },
                    { "66fd5601-8406-4165-8858-8f6ab6dc6d70", "2be92494-0034-458b-9fe7-b57382f9afff", "Coach", "COACH" },
                    { "7001820c-9833-4d09-8b80-f59eea7ee3b1", "88a83b78-308c-42fe-8456-6bd2927efc85", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
