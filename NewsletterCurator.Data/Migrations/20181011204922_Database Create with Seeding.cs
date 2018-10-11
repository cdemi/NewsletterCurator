using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class DatabaseCreatewithSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recepients",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepients", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Newsitems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsitems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Newsitems_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"), "DevOps" },
                    { new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"), "Front End" },
                    { new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "Security" },
                    { new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"), "iGaming" },
                    { new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"), ".NET" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Newsitems_CategoryID",
                table: "Newsitems",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newsitems");

            migrationBuilder.DropTable(
                name: "Recepients");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
