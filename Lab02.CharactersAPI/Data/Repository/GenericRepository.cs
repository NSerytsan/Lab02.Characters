using Lab02.CharactersAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab02.CharactersAPI.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CharactersDbContext _context;

    public GenericRepository(CharactersDbContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);

        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity is not null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }

    public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetAsync(int? id)
    {
        if (id is null)
        {
            return null;
        }

        return await _context.Set<T>().FindAsync(id);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
