using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class Addedsomehashtagstocategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "Security,InfoSec");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("917ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Humor,Funny");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "HashTags",
                value: "dotNet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "Security");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("917ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Humor");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "HashTags",
                value: "dotnet");
        }
    }
}
