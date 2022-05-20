using Lab02.Characters.Models.Dtos.WeaponType;

namespace Lab02.Characters.Client.Services.Contracts;

public interface IWeaponTypeService
{
    Task<IEnumerable<WeaponTypeDto>> GetAll();
    Task<WeaponTypeDto> Get(int id);
}
