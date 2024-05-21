using Microsoft.EntityFrameworkCore;
using VectoVia.Models.KompaniaRents.Model;




namespace VectoVia.Models.KompaniaRents
{
    public class KompaniaRentDbContext : DbContext
    {


        public KompaniaRentDbContext(DbContextOptions<KompaniaRentDbContext> options) : base(options)
        {
        }

        public DbSet<KompaniaRent> KompaniaRents { get; set; }
    }

}
