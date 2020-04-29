using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Postgres.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Priority = table.Column<float>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    HashTags = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DateSubscribed = table.Column<DateTimeOffset>(nullable: true),
                    DateValidated = table.Column<DateTimeOffset>(nullable: true),
                    DateUnsubscribed = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Newsitems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTimeOffset>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false),
                    IsAlreadySent = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    FaviconURL = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsitems", x => x.ID);
                    table.UniqueConstraint("AK_Newsitems_URL", x => x.URL);
                    table.ForeignKey(
                        name: "FK_Newsitems_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Color", "HashTags", "Name", "Priority" },
                values: new object[,]
                {
                    { new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"), "#004D40", "Data", "Data", 3.5f },
                    { new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"), "#2C8693", "dotNet", ".NET", 1f },
                    { new Guid("917ff497-33a2-424c-a1db-5a722d94078f"), "#ef0078", "Humor,Funny", "Humor", 100f },
                    { new Guid("927ff497-33a2-424c-a1db-5a722d94078f"), "#ef0078", "Random", "Random", 90f },
                    { new Guid("123ff497-33a2-424c-a1db-5a722d940456"), "#1dae0b", "Politics", "Politics", 89.5f },
                    { new Guid("927af497-33a2-424c-a1db-5a722d92078a"), "#a74141", "Healthcare,Medical", "Healthcare", 89f },
                    { new Guid("847ff497-33a2-424c-a1db-5a722d94078f"), "#795548", "Design", "Design", 6f },
                    { new Guid("317ff497-33d2-434c-a1db-5a722d94078f"), "#607d8b", "SoftwareDevelopment,Software,Dev,Programming", "Software Development", 0f },
                    { new Guid("622fa497-32d2-434c-a1db-5a722d94012f"), "#6e179b", "IoT,InternetOfThings", "Internet of Things", 4.5f },
                    { new Guid("527ff497-33d2-434c-a1db-5a722d94078f"), "#ff5722", "Infrastructure,sysadmin", "Infrastructure", 4f },
                    { new Guid("127ff497-33d2-734c-a1db-5a722a94078f"), "#77b53f", "Serverless", "Serverless", 3.6f },
                    { new Guid("127ff497-11d2-724c-a1db-5a722d94078f"), "#2c90d7", "Kubernetes,k8s", "Kubernetes", 3.45f },
                    { new Guid("527ff497-33d2-724c-a1db-5a722d94078f"), "#0336ff", "Cloud", "Cloud", 3.4f },
                    { new Guid("497ff497-33d2-434c-a1db-5a722d94078f"), "#ff9800", "Tech", "General Tech", 8f },
                    { new Guid("33754987-6f3f-4b5e-a79d-a61b13a61647"), "#1abaa4", "Gaming", "Gaming", 8.9f },
                    { new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"), "#ca9a07", "Gambling,SportsBetting,Casino", "Gambling", 9f },
                    { new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"), "#8bc34a", "eSports", "eSports", 8.5f },
                    { new Guid("12e0baf7-3b82-4866-b9ae-5a2e77ad88fb"), "#683864", "Product,ProductOwnership,ProductManagement", "Product", 5.9f },
                    { new Guid("01f3205e-578b-4568-3d87-5c15fceb6a4f"), "#e91e63", "BigData", "Big Data", 3.6f },
                    { new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"), "#673ab7", "DevOps", "DevOps", 3f },
                    { new Guid("219acf3f-bf48-455d-9a3f-f660cd3a13b3"), "#F50057", "UX,UserExperience", "User Experience", 2.5f },
                    { new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"), "#3f51b5", "FrontEnd", "Front End", 2f },
                    { new Guid("67e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#388f5b", "Robotics", "Robotics", 6.9f },
                    { new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#2196f3", "AI,ArtificialIntelligence", "Artificial Intelligence", 7f },
                    { new Guid("21e0baf7-4b80-4866-b9ae-3a2e77ad88fb"), "#6f8b60", "Blockchain,Crypto,Cryptocurrency", "Blockchain and Cryptocurrencies", 9.5f },
                    { new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#03a9f4", "Space", "Space", 10f },
                    { new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#00bcd4", "Security,InfoSec", "Security", 5f },
                    { new Guid("30e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#b65050", "Privacy", "Privacy", 5.1f },
                    { new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#009688", "Hardware", "Hardware", 5.5f },
                    { new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), "#4caf50", "QA,QualityAssurance", "Quality Assurance", 5.8f },
                    { new Guid("91e0baf7-3c82-4866-b9ae-5a2e77ad88fa"), "#57106e", "Business", "Business", 5.85f },
                    { new Guid("32e0baf7-4b80-4866-b9ae-3a2e77ad88fb"), "#bc4dd1", "QuantumComputing,Quantum", "Quantum Computing", 9.5f }
                });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ID", "DateSubscribed", "DateUnsubscribed", "DateValidated", "Email" },
                values: new object[,]
                {
                    { new Guid("ff6f302b-8266-4d45-978a-9e8456b593c4"), new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "test@test.test" },
                    { new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"), new DateTimeOffset(new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "test2@test.test" }
                });

            migrationBuilder.InsertData(
                table: "Newsitems",
                columns: new[] { "ID", "CategoryID", "DateTime", "FaviconURL", "ImageURL", "IsAlreadySent", "Summary", "Tags", "Title", "URL" },
                values: new object[,]
                {
                    { new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"), new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), new DateTimeOffset(new DateTime(2018, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "https://regmedia.co.uk/2018/01/23/mr_freeze.jpg", false, "Hardware hackers bring cold boot attacks out of the deep freeze", null, "You'll never guess what you can do once you steal a laptop, reflash the BIOS, and reboot it", "https://www.theregister.co.uk/2018/09/14/cold_boot_attack_reloaded/" },
                    { new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"), new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), new DateTimeOffset(new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "https://cdn.wccftech.com/wp-content/uploads/2018/09/apple-a12-bionic-header-wccftech.com_-740x418.jpg", false, "Apple's A12 and S4 processor upgrade boot-level security. Take a look here for all of the changes and more.", null, "4 New Security Features For Apple A12 And S4 That Weren't Mentioned Onstage", "https://wccftech.com/4-new-security-features-for-apple-a12-and-s4-that-werent-mentioned-onstage/" },
                    { new Guid("6df0545e-0b4b-4162-f391-08d632ced619"), new Guid("317ff497-33d2-434c-a1db-5a722d94078f"), new DateTimeOffset(new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "https://www.confluent.io/wp-content/uploads/Event-Driven-2.0-–-Data-as-a-Service.png", false, "Streaming systems have led to far richer approaches than the event-driven architectures of old. In the future, data will be as automated and self-service as infrastructure is today, in the form of data as a service.", null, "Event Driven 2.0: Data as a Service | Confluent", "https://www.confluent.io/blog/event-driven-2-0-data-service" },
                    { new Guid("d68f05e8-94f8-4e99-9b03-08d6329b2519"), new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"), new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, null, false, "For the past couple of years, Microsoft has been developing two forms of the SignalR – the original ASP.NET SignalR library and the newer ASP.NET Core SignalR.  This fall will see the last major update to the legacy ASP.NET SignalR library.", null, "ASP.NET SignalR 2.4 to Add Azure Support", "https://www.infoq.com/news/2018/10/aspnet-signalr" }
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
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
