using Microsoft.EntityFrameworkCore;
using VectoVia.Models.KompaniaTaksive.Model;

public class QytetiDbContext : DbContext
{
    public QytetiDbContext(DbContextOptions<QytetiDbContext> options) : base(options)
    {
    }

    public DbSet<Qyteti> Qyteti { get; set; }

}
