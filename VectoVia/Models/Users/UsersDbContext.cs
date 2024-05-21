using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Users.Model;


namespace VectoVia.Models.Users
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
