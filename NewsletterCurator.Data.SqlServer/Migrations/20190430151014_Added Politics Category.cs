using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedPoliticsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTag", "Name", "Priority" },
                values: new object[] { new Guid("123ff497-33a2-424c-a1db-5a722d940456"), "#1dae0b", "Politics", "Politics", 89.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("123ff497-33a2-424c-a1db-5a722d940456"));
        }
    }
}
