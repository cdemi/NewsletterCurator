using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewsletterCurator.Data
{
    public class NewsletterCuratorContext : DbContext
    {
        public NewsletterCuratorContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Newsitem>(options =>
            {
                options.HasData(
                    new Newsitem
                    {
                        ID = new Guid("D68F05E8-94F8-4E99-9B03-08D6329B2519"),
                        DateTime = new DateTimeOffset(new DateTime(2018, 10, 15)),
                        Title = "ASP.NET SignalR 2.4 to Add Azure Support",
                        Summary = "For the past couple of years, Microsoft has been developing two forms of the SignalR – the original ASP.NET SignalR library and the newer ASP.NET Core SignalR.  This fall will see the last major update to the legacy ASP.NET SignalR library.",
                        URL = "https://www.infoq.com/news/2018/10/aspnet-signalr",
                        CategoryID = new Guid("E17226A6-BED1-44F5-863F-3970BB634FCE"),
                        IsAlreadySent = false
                    },
                    new Newsitem
                    {
                        ID = new Guid("0A8A1CA1-29E9-473E-1B07-08D632B276CB"),
                        DateTime = new DateTimeOffset(new DateTime(2018, 10, 15)),
                        Title = "You'll never guess what you can do once you steal a laptop, reflash the BIOS, and reboot it",
                        Summary = "Hardware hackers bring cold boot attacks out of the deep freeze",
                        ImageURL = "https://regmedia.co.uk/2018/01/23/mr_freeze.jpg",
                        URL = "https://www.theregister.co.uk/2018/09/14/cold_boot_attack_reloaded/",
                        CategoryID = new Guid("40E0BAF7-3B80-4866-B9AE-3A2E77AD88FB"),
                        IsAlreadySent = false
                    },
                    new Newsitem
                    {
                        ID = new Guid("D501A11E-26A3-423B-1B06-08D632B276CB"),
                        DateTime = new DateTimeOffset(new DateTime(2018, 10, 15)),
                        Title = "4 New Security Features For Apple A12 And S4 That Weren't Mentioned Onstage",
                        Summary = "Apple's A12 and S4 processor upgrade boot-level security. Take a look here for all of the changes and more.",
                        ImageURL = "https://cdn.wccftech.com/wp-content/uploads/2018/09/apple-a12-bionic-header-wccftech.com_-740x418.jpg",
                        URL = "https://wccftech.com/4-new-security-features-for-apple-a12-and-s4-that-werent-mentioned-onstage/",
                        CategoryID = new Guid("40E0BAF7-3B80-4866-B9AE-3A2E77AD88FB"),
                        IsAlreadySent = false
                    },
                    new Newsitem
                    {
                        ID = new Guid("6DF0545E-0B4B-4162-F391-08D632CED619"),
                        DateTime = new DateTimeOffset(new DateTime(2018, 10, 15)),
                        Title = "Event Driven 2.0: Data as a Service | Confluent",
                        Summary = "Streaming systems have led to far richer approaches than the event-driven architectures of old. In the future, data will be as automated and self-service as infrastructure is today, in the form of data as a service.",
                        ImageURL = "https://www.confluent.io/wp-content/uploads/Event-Driven-2.0-–-Data-as-a-Service.png",
                        URL = "https://www.confluent.io/blog/event-driven-2-0-data-service",
                        CategoryID = new Guid("317FF497-33D2-434C-A1DB-5A722D94078F"),
                        IsAlreadySent = false
                    }
                );
            });

            modelBuilder.Entity<Newsitem>().HasAlternateKey(n => n.URL);

            modelBuilder.Entity<Category>(options =>
            {
                options.HasData(
                    new Category { ID = new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"), Name = "DevOps", Priority = 3 },
                    new Category { ID = new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"), Name = "Front End", Priority = 2 },
                    new Category { ID = new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "AI", Priority = 7 },
                    new Category { ID = new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "Space", Priority = 10 },
                    new Category { ID = new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "Security", Priority = 5 },
                    new Category { ID = new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "Hardware", Priority = 5.5f },
                    new Category { ID = new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"), Name = "eSports", Priority = 8.5f },
                    new Category { ID = new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"), Name = "iGaming", Priority = 9 },
                    new Category { ID = new Guid("497FF497-33D2-434C-A1DB-5A722D94078F"), Name = "General Tech", Priority = 8 },
                    new Category { ID = new Guid("527FF497-33D2-434C-A1DB-5A722D94078F"), Name = "Infrastructure", Priority = 4 },
                    new Category { ID = new Guid("317FF497-33D2-434C-A1DB-5A722D94078F"), Name = "Software Development", Priority = 0 },
                    new Category { ID = new Guid("847FF497-33A2-424C-A1DB-5A722D94078F"), Name = "Design", Priority = 6 },
                    new Category { ID = new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"), Name = ".NET", Priority = 1 }
                        );
            });
        }

        public IQueryable<IGrouping<Category, Newsitem>> NewsitemsByCategory()
        {
            return Newsitems.Where(n => n.IsAlreadySent == false).GroupBy(n => n.Category).OrderBy(c => c.Key.Priority);
        }


        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Newsitem> Newsitems { get; set; }
    }

}
