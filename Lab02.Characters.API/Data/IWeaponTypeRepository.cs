using Lab02.Characters.API.Entities;

namespace Lab02.Characters.API.Data;

public interface IWeaponTypeRepository
{
    Task<IEnumerable<WeaponType>> GetAllAsync();
    Task<WeaponType?> GetAsync(int? id);
    Task UpdateAsync(WeaponType weaponType);
    Task<WeaponType> AddAsync(WeaponType weaponType);
    Task DeleteAsync(int id);
}
