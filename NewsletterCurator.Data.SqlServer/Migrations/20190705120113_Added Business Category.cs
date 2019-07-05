using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedBusinessCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("91e0baf7-3c82-4866-b9ae-5a2e77ad88fa"), "#57106e", "Business", "Business", 5.85f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("91e0baf7-3c82-4866-b9ae-5a2e77ad88fa"));
        }
    }
}
