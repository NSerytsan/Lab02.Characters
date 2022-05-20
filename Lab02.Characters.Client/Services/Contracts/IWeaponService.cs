using Lab02.Characters.Models.Dtos.Weapon;

namespace Lab02.Characters.Client.Services.Contracts;

public interface IWeaponService
{
    Task<IEnumerable<WeaponDto>> GetAllAsync();
    Task<WeaponDto> GetAsync(int id);
    Task<WeaponDto> AddAsync(CreateWeaponDto weaponType);
    Task UpdateAsync(UpdateWeaponDto weaponType);
    Task DeleteAsync(int id);
}
