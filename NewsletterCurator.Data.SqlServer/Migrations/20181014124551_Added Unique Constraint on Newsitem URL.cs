using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedUniqueConstraintonNewsitemURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Newsitems",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Newsitems_URL",
                table: "Newsitems",
                column: "URL");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("497ff497-33d2-434c-a1db-5a722d94078f"), "General Tech" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Newsitems_URL",
                table: "Newsitems");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("497ff497-33d2-434c-a1db-5a722d94078f"));

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Newsitems",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
