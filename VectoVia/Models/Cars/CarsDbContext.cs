using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Cars.Model;
using VectoVia_LabCourse.Models.Cars.Model;

namespace vectovia.Models.Cars
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {

        }

        public DbSet<Car> CarDBO { get; set; }
        public DbSet<Marka> Markat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Marka)
                .WithMany(m => m.CarDBO)
                .HasForeignKey(c => c.MarkaID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
