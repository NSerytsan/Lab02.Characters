namespace Lab02.CharactersAPI.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(int? id);
    Task<List<T>> GetAllAsync();
    Task<T> AddSync(T entity);
    Task DeleteAsync(int id);
    Task UpdateAsync(T entity);
    Task<bool> Exists(int id);
}