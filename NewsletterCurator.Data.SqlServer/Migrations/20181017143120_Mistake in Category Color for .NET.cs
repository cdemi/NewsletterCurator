using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class MistakeinCategoryColorforNET : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "Color",
                value: "#2C869");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "Color",
                value: "#2C8693");
        }
    }
}
