using Lab02.CharactersAPI.Interfaces;
using Lab02.CharactersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab02.CharactersAPI.Data.Repository;

public class WeaponTypeRepository : GenericRepository<WeaponType>, IWeaponTypeRepository
{
    private readonly CharactersDbContext _context;

    public WeaponTypeRepository(CharactersDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<WeaponType?> GetDetailsAsync(int id)
    {

        return await _context.WeaponTypes.Include(wt => wt.Weapons).FirstOrDefaultAsync(wt => wt.Id == id);
    }

    
}
