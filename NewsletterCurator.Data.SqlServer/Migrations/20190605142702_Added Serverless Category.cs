using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedServerlessCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTag", "Name", "Priority" },
                values: new object[] { new Guid("127ff497-33d2-734c-a1db-5a722a94078f"), "#77b53f", "Serverless", "Serverless", 3.6f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("127ff497-33d2-734c-a1db-5a722a94078f"));
        }
    }
}
