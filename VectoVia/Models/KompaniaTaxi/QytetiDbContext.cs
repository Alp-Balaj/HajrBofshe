using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace VectoVia.Models.KompaniaTaxi
{


    public class QytetiDbContext : DbContext
    {

        public QytetiDbContext(DbContextOptions<QytetiDbContext> options) : base(options)
        {

        }
        public DbSet<Model.Qyteti> Qytetet { get; set; }
    }

}

