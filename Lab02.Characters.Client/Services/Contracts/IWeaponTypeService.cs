using Lab02.Characters.Models.Dtos.WeaponType;

namespace Lab02.Characters.Client.Services.Contracts;

public interface IWeaponTypeService
{
    Task<IEnumerable<WeaponTypeDto>> GetAllAsync();
    Task<WeaponTypeDto> GetAsync(int id);
    Task<WeaponTypeDto> AddAsync(CreateWeaponTypeDto weaponType);
    Task UpdateAsync(UpdateWeaponTypeDto weaponType);
    Task DeleteAsync(int id);
}
