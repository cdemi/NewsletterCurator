using Microsoft.EntityFrameworkCore;

namespace NewsletterCurator.Data
{
    public class NewsletterCuratorContext : DbContext
    {
        public NewsletterCuratorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recepient> Recepients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Newsitem> Newsitems { get; set; }
    }
}
