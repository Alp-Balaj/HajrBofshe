using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Cars.Model;

namespace VectoVia.Models.Cars.NewFolder
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
