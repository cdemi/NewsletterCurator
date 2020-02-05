using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedPrivacyCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("30e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#b65050", "Privacy", "Privacy", 5.1f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("30e0baf7-3b80-4866-b9ae-3a2e77ad88fb"));
        }
    }
}
