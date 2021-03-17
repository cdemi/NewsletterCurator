using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedOpenShiftCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("138af497-11d2-724c-a1db-5a722d94078f"), "#d82020", "OpenShift,OKD", "OpenShift", 3.46f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("138af497-11d2-724c-a1db-5a722d94078f"));
        }
    }
}
