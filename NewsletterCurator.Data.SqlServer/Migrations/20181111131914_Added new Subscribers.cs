using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddednewSubscribers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ID", "DateSubscribed", "DateUnsubscribed", "DateValidated", "Email" },
                values: new object[] { new Guid("ff6f302b-8266-4d45-978a-9e8456b593c4"), new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "test@test.test" });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ID", "DateSubscribed", "DateUnsubscribed", "DateValidated", "Email" },
                values: new object[] { new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"), new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "test2@test.test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"));

            migrationBuilder.DeleteData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("ff6f302b-8266-4d45-978a-9e8456b593c4"));
        }
    }
}
