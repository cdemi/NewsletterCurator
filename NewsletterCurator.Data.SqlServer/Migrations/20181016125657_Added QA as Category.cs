using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedQAasCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name", "Priority" },
                values: new object[] { new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "Quality Assurance", 5.8f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"));
        }
    }
}
