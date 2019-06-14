using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class ChangedHashTagtolist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashTag",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "HashTags",
                table: "Categories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-3d87-5c15fceb6a4f"),
                column: "HashTags",
                value: "BigData");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "HashTags",
                value: "Data");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("123ff497-33a2-424c-a1db-5a722d940456"),
                column: "HashTags",
                value: "Politics");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("127ff497-33d2-734c-a1db-5a722a94078f"),
                column: "HashTags",
                value: "Serverless");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "Space");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("219acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                column: "HashTags",
                value: "UX,UserExperience");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "SoftwareDevelopment,Software");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("33754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "HashTags",
                value: "Gaming");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                column: "HashTags",
                value: "FrontEnd");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "Security");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "HashTags",
                value: "Gambling");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("497ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Tech");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("527ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Infrastructure,sysadmin");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("527ff497-33d2-724c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Cloud");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                columns: new[] { "HashTags", "Name" },
                values: new object[] { "AI,ArtificalIntelligence", "Artifical Intelligence" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("622fa497-32d2-434c-a1db-5a722d94012f"),
                columns: new[] { "HashTags", "Name" },
                values: new object[] { "IoT,InternetofThings", "Internet of Things" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "HashTags",
                value: "eSports");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("847ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("917ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Humor");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("927af497-33a2-424c-a1db-5a722d92078a"),
                columns: new[] { "HashTags", "Name" },
                values: new object[] { "Healthcare,Medical", "Healthcare" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("927ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTags",
                value: "Random");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "QA,Quality Assurance");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTags",
                value: "Hardware");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "HashTags",
                value: "DevOps");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "HashTags",
                value: "dotnet");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[] { new Guid("127ff497-11d2-724c-a1db-5a722d94078f"), "#2c90d7", "Kubernetes,k8s", "Kubernetes", 3.45f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("127ff497-11d2-724c-a1db-5a722d94078f"));

            migrationBuilder.DropColumn(
                name: "HashTags",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "HashTag",
                table: "Categories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-3d87-5c15fceb6a4f"),
                column: "HashTag",
                value: "BigData");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "HashTag",
                value: "Data");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("123ff497-33a2-424c-a1db-5a722d940456"),
                column: "HashTag",
                value: "Politics");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("127ff497-33d2-734c-a1db-5a722a94078f"),
                column: "HashTag",
                value: "Serverless");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTag",
                value: "Space");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("219acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                column: "HashTag",
                value: "UX");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "SoftwareDevelopment");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("33754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "HashTag",
                value: "Gaming");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                column: "HashTag",
                value: "FrontEnd");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTag",
                value: "Security");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "HashTag",
                value: "Gambling");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("497ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "Tech");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("527ff497-33d2-434c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "Infrastructure");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("527ff497-33d2-724c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "Cloud");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                columns: new[] { "HashTag", "Name" },
                values: new object[] { "AI", "AI" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("622fa497-32d2-434c-a1db-5a722d94012f"),
                columns: new[] { "HashTag", "Name" },
                values: new object[] { "IoT", "IoT" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"),
                column: "HashTag",
                value: "eSports");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("847ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("917ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "Humor");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("927af497-33a2-424c-a1db-5a722d92078a"),
                columns: new[] { "HashTag", "Name" },
                values: new object[] { "Medical", "Medical" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("927ff497-33a2-424c-a1db-5a722d94078f"),
                column: "HashTag",
                value: "Random");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTag",
                value: "QA");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                column: "HashTag",
                value: "Hardware");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"),
                column: "HashTag",
                value: "DevOps");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                column: "HashTag",
                value: "dotnet");
        }
    }
}
