using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class FixedQCSpellingMistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("32e0baf7-4b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "QuantumComputing,Quantum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("32e0baf7-4b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "Quantum Computing,Quantum");
        }
    }
}
