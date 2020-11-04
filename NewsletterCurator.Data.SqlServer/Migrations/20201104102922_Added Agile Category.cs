using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedAgileCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("23e0baf7-3b82-4866-b8ae-5a2e77ad88fb"), "#b53f44", "Agile,Scrum", "Agile", 5.84f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("23e0baf7-3b82-4866-b8ae-5a2e77ad88fb"));
        }
    }
}
