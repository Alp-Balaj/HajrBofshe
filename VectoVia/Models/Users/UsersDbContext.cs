using Microsoft.EntityFrameworkCore;
using VectoVia.Models.KompaniaTaksive.Model;
using VectoVia.Models.Users.Model;


namespace VectoVia.Models.Users
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)           // Each User has one Role
                .WithMany(r => r.Users)        // Each Role has many Users
                .HasForeignKey(u => u.RoleID)  // The foreign key in User
                .OnDelete(DeleteBehavior.Restrict); // Optional: Define the delete behavior

            modelBuilder.Entity<Role>()
                .Property(r => r.RoleID)
                .ValueGeneratedNever();         // Ensure RoleID is not auto-generated

        }

    }
}
