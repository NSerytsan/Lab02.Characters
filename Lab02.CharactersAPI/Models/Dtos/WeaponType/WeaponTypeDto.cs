using Lab02.CharactersAPI.Models.Dtos.Weapon;

namespace Lab02.CharactersAPI.Models.Dtos.WeaponType;

public class WeaponTypeDto : BaseWeaponTypeDto
{
    public int Id { get; set; }
    public List<WeaponDto> Weapons { get; set; } = null!;
}
