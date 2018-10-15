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

            modelBuilder.Entity<Newsitem>().HasAlternateKey(n => n.URL);

            modelBuilder.Entity<Category>(options =>
            {
                options.HasData(
                    new Category { ID = new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"), Name = "DevOps" },
                    new Category { ID = new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"), Name = "Front End" },
                    new Category { ID = new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "AI" },
                    new Category { ID = new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "Space" },
                    new Category { ID = new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"), Name = "Security" },
                    new Category { ID = new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"), Name = "iGaming" },
                    new Category { ID = new Guid("497FF497-33D2-434C-A1DB-5A722D94078F"), Name = "General Tech" },
                    new Category { ID = new Guid("527FF497-33D2-434C-A1DB-5A722D94078F"), Name = "Infrastructure" },
                    new Category { ID = new Guid("317FF497-33D2-434C-A1DB-5A722D94078F"), Name = "Software Development" },
                    new Category { ID = new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"), Name = ".NET" }
                        );
            });
        }

        public IQueryable<IGrouping<Category, Newsitem>> NewsitemsByCategory()
        {
            return Newsitems.Where(n => n.IsAlreadySent == false).GroupBy(n => n.Category);
        }


        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Newsitem> Newsitems { get; set; }
    }

}
