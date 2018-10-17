using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedCategoryColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("497ff497-33d2-434c-a1db-5a722d94078f"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("527ff497-33d2-434c-a1db-5a722d94078f"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("847ff497-33a2-424c-a1db-5a722d94078f"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "Color",
                value: "#2C8693");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "Color",
                value: "#2C869");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");
        }
    }
}
