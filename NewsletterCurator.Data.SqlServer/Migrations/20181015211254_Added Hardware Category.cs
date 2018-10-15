using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedHardwareCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name", "Priority" },
                values: new object[] { new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "Hardware", 5.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"));
        }
    }
}
