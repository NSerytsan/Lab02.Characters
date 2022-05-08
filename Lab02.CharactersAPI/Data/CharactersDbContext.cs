using Lab02.CharactersAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab02.CharactersAPI.Data
{
    public class CharactersDbContext : DbContext
    {
        public virtual DbSet<Biography> Biographies { get; set; } = null!;

        public CharactersDbContext(DbContextOptions<CharactersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
