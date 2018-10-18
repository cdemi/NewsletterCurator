using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedDatabasesCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "Name", "Priority" },
                values: new object[] { new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"), "#004D40", "Databases", 3.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"));
        }
    }
}
