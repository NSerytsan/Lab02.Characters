using Lab02.CharactersAPI.Interfaces;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Data.Repository;

public class WeaponTypeRepository : GenericRepository<WeaponType>, IWeaponTypeRepository
{
    private readonly CharactersDbContext _context;

    public WeaponTypeRepository(CharactersDbContext context) : base(context)
    {
        _context = context;
    }
}
