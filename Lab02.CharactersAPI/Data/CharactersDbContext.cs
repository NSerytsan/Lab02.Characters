using Lab02.CharactersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab02.CharactersAPI.Data
{
    public class CharactersDbContext : DbContext
    {
        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Weapon> Weapons { get; set; } = null!;
        public virtual DbSet<WeaponType> WeaponTypes { get; set; } = null!;
        
        public CharactersDbContext(DbContextOptions<CharactersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
