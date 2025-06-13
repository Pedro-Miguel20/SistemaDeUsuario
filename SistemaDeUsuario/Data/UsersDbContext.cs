using Microsoft.EntityFrameworkCore;

namespace SistemaDeUsuario.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options)
        {
        }
        public DbSet<SistemaDeUsuario.Models.User> Users { get; set; }

    }


}
