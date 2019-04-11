using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class ChangingSeedDataDatestoseecorrectordering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("6df0545e-0b4b-4162-f391-08d632ced619"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"),
                column: "DateTime",
                value: new DateTimeOffset(new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
