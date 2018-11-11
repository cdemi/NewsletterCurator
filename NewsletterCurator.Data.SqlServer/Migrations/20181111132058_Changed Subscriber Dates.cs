using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class ChangedSubscriberDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"),
                columns: new[] { "DateSubscribed", "DateValidated" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"),
                columns: new[] { "DateSubscribed", "DateValidated" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
