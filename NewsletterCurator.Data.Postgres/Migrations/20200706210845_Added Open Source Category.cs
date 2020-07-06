using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Postgres.Migrations
{
    public partial class AddedOpenSourceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("847bf497-33a2-424c-a1db-5a722d94078a"), "#88b224", "Open Source,OSS,FOSS", "Open Source", 5.7f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("847bf497-33a2-424c-a1db-5a722d94078a"));
        }
    }
}
