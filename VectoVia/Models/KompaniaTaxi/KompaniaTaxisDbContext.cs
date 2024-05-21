using Microsoft.EntityFrameworkCore;
using VectoVia.Models.KompaniaTaxi.Model;



namespace VectoVia.Models.KompaniaTaxi
{
    public class KompaniaTaxisDbContext : DbContext
    {
        public KompaniaTaxisDbContext(DbContextOptions<KompaniaTaxisDbContext> options) : base(options)
        {
        }

        public DbSet<Model.KompaniaTaxi> KompaniaTaxis { get; set; }
    }

}
