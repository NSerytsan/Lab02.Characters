using Lab02.CharactersAPI.Interfaces;
using Lab02.CharactersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab02.CharactersAPI.Data.Repository;

public class WeaponRepository : GenericRepository<Weapon>, IWeaponRepository
{
    private readonly CharactersDbContext _context;

    public WeaponRepository(CharactersDbContext context) : base(context)
    {
        _context = context;
    }
}
