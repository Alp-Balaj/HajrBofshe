using Microsoft.EntityFrameworkCore;
using VectoVia.Models.TaxiCars.Model;

namespace VectoVia.Models.TaxiCars
{
    public class TaxiCarsDbContext : DbContext
    {
        public TaxiCarsDbContext(DbContextOptions<TaxiCarsDbContext> options) : base(options)
        {

        }

        public DbSet<TaxiCar> TaxiCars { get; set; }
    }
}
