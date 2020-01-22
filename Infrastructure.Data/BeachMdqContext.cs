using System.Threading;
using System.Threading.Tasks;
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
        
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Carp> Carps { get; set; }
        public DbSet<Spa> Spas { get; set; }
        public DbSet<Umbrella> Umbrellas { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.SetAuditProperties();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
