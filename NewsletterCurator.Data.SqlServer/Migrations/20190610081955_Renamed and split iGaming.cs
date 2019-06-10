using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class RenamedandsplitiGaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"),
                columns: new[] { "HashTag", "Name" },
                values: new object[] { "Gambling", "Gambling" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTag", "Name", "Priority" },
                values: new object[] { new Guid("33754987-6f3f-4b5e-a79d-a61b13a61647"), "#1abaa4", "Gaming", "Gaming", 8.9f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("33754987-6f3f-4b5e-a79d-a61b13a61647"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"),
                columns: new[] { "HashTag", "Name" },
                values: new object[] { "iGaming", "iGaming" });
        }
    }
}
