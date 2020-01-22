using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BeachMdqContext : DbContext
    {
        public BeachMdqContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Beach> Beaches { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Flag> Flags { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
