using Lab02.CharactersAPI.Dtos.Weapon;

namespace Lab02.CharactersAPI.Dtos.WeaponTypes;

public class WeaponTypeDto : BaseWeaponTypeDto
{
    public int Id { get; set; }
    public List<WeaponDto> Weapons { get; set; } = null!;
}
