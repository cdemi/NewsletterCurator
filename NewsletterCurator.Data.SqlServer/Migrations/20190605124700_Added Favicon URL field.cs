using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class AddedFaviconURLfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaviconURL",
                table: "Newsitems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaviconURL",
                table: "Newsitems");
        }
    }
}
