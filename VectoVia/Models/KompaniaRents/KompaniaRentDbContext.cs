using Microsoft.EntityFrameworkCore;
using vectovia.Models.PickUpLocations.Model;
using VectoVia.Models.KompaniaRents.Model;

namespace VectoVia.Data
{
    public class KompaniaRentDbContext : DbContext
    {
        public KompaniaRentDbContext(DbContextOptions<KompaniaRentDbContext> options)
            : base(options)
        {
        }

        public DbSet<KompaniaRent> KompaniaRents { get; set; }
        public DbSet<PickUpLocation> PickUpLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PickUpLocation>()
                .HasOne(p => p.KompaniaRent)
                .WithMany(k => k.PickUpLocations)
                .HasForeignKey(p => p.CompanyID);
        }
    }
}
