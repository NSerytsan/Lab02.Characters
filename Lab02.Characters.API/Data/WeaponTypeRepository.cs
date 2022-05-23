using Lab02.Characters.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab02.Characters.API.Data;

public class WeaponTypeRepository : IWeaponTypeRepository
{
    private readonly CharactersDbContext _context;

    public WeaponTypeRepository(CharactersDbContext context)
    {
        _context = context;
    }

    public async Task<WeaponType> AddAsync(WeaponType weaponType)
    {
        var result = await _context.WeaponTypes.AddAsync(weaponType);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var weaponType = await _context.WeaponTypes.FirstOrDefaultAsync(wt => wt.Id == id);
        if (weaponType is not null)
        {
            _context.WeaponTypes.Remove(weaponType);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<WeaponType>> GetAllAsync()
    {
        return await _context.WeaponTypes.ToListAsync();
    }

    public async Task<WeaponType?> GetAsync(int? id)
    {
        if (id is null || _context.WeaponTypes is null)
            return null;

        return await _context.WeaponTypes.FindAsync(id);
    }

    public Task UpdateAsync(WeaponType weaponType)
    {
        throw new NotImplementedException();
    }
}
