using Lab02.Characters.Models.Dtos.Weapon;

namespace Lab02.Characters.Client.Services.Contracts;

public interface IWeaponService
{
    Task<IEnumerable<WeaponDto>> GetAllAsync();
    Task<WeaponDto> GetAsync(int id);
    Task<WeaponDto> AddAsync(CreateWeaponDto weapon);
    Task UpdateAsync(UpdateWeaponDto weapon);
    Task DeleteAsync(int id);
}
