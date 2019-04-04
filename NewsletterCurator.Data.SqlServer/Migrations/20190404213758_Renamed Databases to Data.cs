using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class RenamedDatabasestoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "Name",
                value: "Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "Name",
                value: "Databases");
        }
    }
}
