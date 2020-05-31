using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportDash.Migrations
{
    public partial class InsertDataToPlaygroundReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playgroundReservations",
                columns: new[] { "Id", "Date", "EndTime", "Name", "PlaygroundId", "StartTime", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0), "userA", "1dc196be-3c4b-435a-8eb5-fffb05ad8a66", new TimeSpan(0, 6, 0, 0, 0), "Waiting", "d209032e-026f-4d77-88eb-e8013acfc073" },
                    { 2, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "userB", "1dc196be-3c4b-435a-8eb5-fffb05ad8a66", new TimeSpan(0, 8, 0, 0, 0), "Waiting", "d6c31671-bbab-493f-98ed-e79ace5fd968" },
                    { 3, new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "userC", "1dc196be-3c4b-435a-8eb5-fffb05ad8a66", new TimeSpan(0, 8, 0, 0, 0), "Waiting", "9419da5f-5e00-40bc-8c52-7f591822794f" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playgroundReservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playgroundReservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "playgroundReservations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
