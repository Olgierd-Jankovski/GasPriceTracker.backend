using Microsoft.EntityFrameworkCore;

namespace Gas.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Price> Prices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
