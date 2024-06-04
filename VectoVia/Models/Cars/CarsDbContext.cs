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

        public DbSet<Car> Car { get; set; }
        public DbSet<Marka> Marka { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Marka)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.MarkaID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
