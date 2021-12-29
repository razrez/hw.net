using Microsoft.EntityFrameworkCore;

namespace hw9.Models
{
    public class CacheContent:DbContext
    {
        public DbSet<Cache> Cache { get; set; }

        public CacheContent(DbContextOptions<CacheContent> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}