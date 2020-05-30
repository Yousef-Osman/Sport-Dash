using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class addedSportsTypePropToApplicationUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "060626e1-550b-4965-bc6f-e1130c75c8ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab1eb4e-cf05-4a20-b728-0660772c4ac4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be78f5fe-e0bf-4529-b25a-c700945b7597");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dba9fd30-08ac-4305-9cb4-56b3b92e84f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18a9e4d-9dce-4b57-b12d-d10f571970f1");

            migrationBuilder.AddColumn<int>(
                name: "SportType",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SportType",
                table: "AspNetUsers");
            
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ab1eb4e-cf05-4a20-b728-0660772c4ac4", "58edde98-c4d6-42f1-ac3d-a1f1edb90ce5", "ClubManager", "CLUBMANAGER" },
                    { "be78f5fe-e0bf-4529-b25a-c700945b7597", "02124aab-a992-4a9b-a4d6-cc89f9f7cca4", "PlaygroundManager", "PLAYGROUNDMANAGER" },
                    { "f18a9e4d-9dce-4b57-b12d-d10f571970f1", "d624978c-7004-43f6-b1c0-00862ce8a578", "GymManager", "GYMMANAGER" },
                    { "dba9fd30-08ac-4305-9cb4-56b3b92e84f7", "a4b7ffd8-fb91-474e-ab5f-60deba7f2ab9", "Coach", "COACH" },
                    { "060626e1-550b-4965-bc6f-e1130c75c8ac", "849c86c0-077b-4355-b678-71749825a6b3", "NormalUser", "NORMALUSER" }
                });
        }
    }
}
