using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedeSportsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name", "Priority" },
                values: new object[] { new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"), "eSports", 8.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"));
        }
    }
}
