using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedUserExperienceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "Name", "Priority" },
                values: new object[] { new Guid("219acf3f-bf48-455d-9a3f-f660cd3a13b3"), "#F50057", "User Experience", 2.5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("219acf3f-bf48-455d-9a3f-f660cd3a13b3"));
        }
    }
}
