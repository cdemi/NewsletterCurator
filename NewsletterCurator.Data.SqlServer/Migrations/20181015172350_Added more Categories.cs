using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedmoreCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "AI" },
                    { new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "Space" },
                    { new Guid("527ff497-33d2-434c-a1db-5a722d94078f"), "Infrastructure" },
                    { new Guid("317ff497-33d2-434c-a1db-5a722d94078f"), "Software Development" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("317ff497-33d2-434c-a1db-5a722d94078f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("527ff497-33d2-434c-a1db-5a722d94078f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"));
        }
    }
}
