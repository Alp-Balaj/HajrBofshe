using Microsoft.EntityFrameworkCore;
using VectoVia.Models.KompaniaTaksive.Model;


public class KompaniaTaxiDbContext : DbContext
{
    public KompaniaTaxiDbContext(DbContextOptions<KompaniaTaxiDbContext> options) : base(options)
    {
    }


    public DbSet<KompaniaTaxi> KompaniaTaxi { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        // Configure your entity relationships here if needed
        // For example, if you want to configure the one-to-many relationship:
        modelBuilder.Entity<KompaniaTaxi>()
            .HasOne(k => k.City)
            .WithMany(q => q.KompaniaTaxis)
            .HasForeignKey(k => k.QytetiId);


}
