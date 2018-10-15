using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsletterCurator.Data.Migrations
{
    public partial class SeedingsomeNewsitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Newsitems",
                columns: new[] { "ID", "CategoryID", "DateTime", "ImageURL", "IsAlreadySent", "Summary", "Title", "URL" },
                values: new object[,]
                {
                    { new Guid("d68f05e8-94f8-4e99-9b03-08d6329b2519"), new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"), new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, false, "For the past couple of years, Microsoft has been developing two forms of the SignalR – the original ASP.NET SignalR library and the newer ASP.NET Core SignalR.  This fall will see the last major update to the legacy ASP.NET SignalR library.", "ASP.NET SignalR 2.4 to Add Azure Support", "https://www.infoq.com/news/2018/10/aspnet-signalr" },
                    { new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"), new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "https://regmedia.co.uk/2018/01/23/mr_freeze.jpg", false, "Hardware hackers bring cold boot attacks out of the deep freeze", "You'll never guess what you can do once you steal a laptop, reflash the BIOS, and reboot it", "https://www.theregister.co.uk/2018/09/14/cold_boot_attack_reloaded/" },
                    { new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"), new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "https://cdn.wccftech.com/wp-content/uploads/2018/09/apple-a12-bionic-header-wccftech.com_-740x418.jpg", false, "Apple's A12 and S4 processor upgrade boot-level security. Take a look here for all of the changes and more.", "4 New Security Features For Apple A12 And S4 That Weren't Mentioned Onstage", "https://wccftech.com/4-new-security-features-for-apple-a12-and-s4-that-werent-mentioned-onstage/" },
                    { new Guid("6df0545e-0b4b-4162-f391-08d632ced619"), new Guid("317ff497-33d2-434c-a1db-5a722d94078f"), new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "https://www.confluent.io/wp-content/uploads/Event-Driven-2.0-–-Data-as-a-Service.png", false, "Streaming systems have led to far richer approaches than the event-driven architectures of old. In the future, data will be as automated and self-service as infrastructure is today, in the form of data as a service.", "Event Driven 2.0: Data as a Service | Confluent", "https://www.confluent.io/blog/event-driven-2-0-data-service" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"));

            migrationBuilder.DeleteData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("6df0545e-0b4b-4162-f391-08d632ced619"));

            migrationBuilder.DeleteData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"));

            migrationBuilder.DeleteData(
                table: "Newsitems",
                keyColumn: "ID",
                keyValue: new Guid("d68f05e8-94f8-4e99-9b03-08d6329b2519"));
        }
    }
}
