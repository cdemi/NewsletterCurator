using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedQuantumComputingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("32e0baf7-4b80-4866-b9ae-3a2e77ad88fb"), "#bc4dd1", "Quantum Computing,Quantum", "Quantum Computing", 9.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("32e0baf7-4b80-4866-b9ae-3a2e77ad88fb"));
        }
    }
}
