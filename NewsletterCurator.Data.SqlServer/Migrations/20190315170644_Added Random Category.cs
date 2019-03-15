using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedRandomCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "Name", "Priority" },
                values: new object[] { new Guid("927ff497-33a2-424c-a1db-5a722d94078f"), "#ef0078", "Random", 90f });

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("6df0545e-0b4b-4162-f391-08d632ced619"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d68f05e8-94f8-4e99-9b03-08d6329b2519"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"),
                columns: new[] { "DateSubscribed", "DateValidated" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("ff6f302b-8266-4d45-978a-9e8456b593c4"),
                columns: new[] { "DateSubscribed", "DateUnsubscribed", "DateValidated" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("927ff497-33a2-424c-a1db-5a722d94078f"));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("6df0545e-0b4b-4162-f391-08d632ced619"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d68f05e8-94f8-4e99-9b03-08d6329b2519"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"),
                columns: new[] { "DateSubscribed", "DateValidated" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Subscribers",
                keyColumn: "ID",
                keyValue: new Guid("ff6f302b-8266-4d45-978a-9e8456b593c4"),
                columns: new[] { "DateSubscribed", "DateUnsubscribed", "DateValidated" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)) });
        }
    }
}
