using Lab02.Characters.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab02.Characters.API.Data
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
