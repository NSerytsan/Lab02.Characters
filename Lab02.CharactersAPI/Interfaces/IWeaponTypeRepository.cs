using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Interfaces;

public interface IWeaponTypeRepository : IGenericRepository<WeaponType>
{
     Task<WeaponType?> GetDetailsAsync(int id);
}
