using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Postgres.Migrations
{
    public partial class AddedArchitectureCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("217f4497-33d2-434c-a1db-5a422d98078f"), "#67ca0c", "Architecture,SoftwareArchitecture,EnterpriseArchitecture", "Architecture", 0.1f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("217f4497-33d2-434c-a1db-5a422d98078f"));
        }
    }
}
