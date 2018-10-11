using System;
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

            modelBuilder.Entity<Category>(options =>
            {
                options.HasData(
                    new Category { ID = Guid.NewGuid(), Name = "DevOps" },
                    new Category { ID = Guid.NewGuid(), Name = "Front End" },
                    new Category { ID = Guid.NewGuid(), Name = "Security" },
                    new Category { ID = Guid.NewGuid(), Name = "iGaming" },
                    new Category { ID = Guid.NewGuid(), Name = ".NET" }
                        );
            });
        }

        public DbSet<Recepient> Recepients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Newsitem> Newsitems { get; set; }
    }
}
