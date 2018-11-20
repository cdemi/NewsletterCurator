using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedHumorCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "Name", "Priority" },
                values: new object[] { new Guid("917ff497-33a2-424c-a1db-5a722d94078f"), "#ef0078", "Humor", 100f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("917ff497-33a2-424c-a1db-5a722d94078f"));
        }
    }
}
