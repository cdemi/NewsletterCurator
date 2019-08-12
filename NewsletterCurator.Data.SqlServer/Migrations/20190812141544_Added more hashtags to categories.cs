using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class Addedmorehashtagstocategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "SoftwareDevelopment,Software,Dev,Programming");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("622fa497-32d2-434c-a1db-5a722d94012f"),
                column: "HashTags",
                value: "IoT,InternetOfThings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "SoftwareDevelopment,Software");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("622fa497-32d2-434c-a1db-5a722d94012f"),
                column: "HashTags",
                value: "IoT,InternetofThings");
        }
    }
}
