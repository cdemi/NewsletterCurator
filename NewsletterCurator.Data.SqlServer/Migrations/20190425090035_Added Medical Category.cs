using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedMedicalCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTag", "Name", "Priority" },
                values: new object[] { new Guid("927af497-33a2-424c-a1db-5a722d92078a"), "#a74141", "Medical", "Medical", 89f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("927af497-33a2-424c-a1db-5a722d92078a"));
        }
    }
}
