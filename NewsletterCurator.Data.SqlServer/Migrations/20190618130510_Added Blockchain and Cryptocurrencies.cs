using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedBlockchainandCryptocurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("21e0baf7-4b80-4866-b9ae-3a2e77ad88fb"), "#6f8b60", "Blockchain,Crypto,Cryptocurrency", "Blockchain and Cryptocurrencies", 9.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("21e0baf7-4b80-4866-b9ae-3a2e77ad88fb"));
        }
    }
}
