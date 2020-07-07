using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Postgres.Migrations
{
    public partial class FixedOpenSourcehashtagspelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("847bf497-33a2-424c-a1db-5a722d94078a"),
                column: "HashTags",
                value: "OpenSource,OSS,FOSS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("847bf497-33a2-424c-a1db-5a722d94078a"),
                column: "HashTags",
                value: "Open Source,OSS,FOSS");
        }
    }
}
