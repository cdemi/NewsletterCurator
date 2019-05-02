using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedIoTCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTag", "Name", "Priority" },
                values: new object[] { new Guid("622fa497-32d2-434c-a1db-5a722d94012f"), "#6e179b", "IoT", "IoT", 4.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("622fa497-32d2-434c-a1db-5a722d94012f"));
        }
    }
}
