using Lab02.Characters.Models.Dtos.WeaponType;

namespace Lab02.Characters.Client.Services.Contracts;

public interface IWeaponTypeService
{
    Task<IEnumerable<WeaponTypeDto>> GetAllAsync();
    Task<WeaponTypeDto> GetAsync(int id);
}
