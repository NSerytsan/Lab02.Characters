using Lab02.CharactersAPI.Interfaces;
using Lab02.CharactersAPI.Data.Repository;


namespace Lab02.CharactersAPI.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly CharactersDbContext _context;

    public UnitOfWork(CharactersDbContext context)
    {
        _context = context;
    }
    public IWeaponRepository WeaponRepository => new WeaponRepository(_context);

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
