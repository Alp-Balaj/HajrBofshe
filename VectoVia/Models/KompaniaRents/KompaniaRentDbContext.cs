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
            modelBuilder.Entity<KompaniaRent>().HasMany(kr => kr.PickUpLocations).WithOne
                 (pl => pl.RentCompany).HasForeignKey(pl => pl.CompanyID);


        }
    }

}