using Lab02.CharactersAPI.Dtos.Weapon;

namespace Lab02.CharactersAPI.Dtos.WeaponType;

public class WeaponTypeDto : BaseWeaponTypeDto
{
    public int Id { get; set; }
    public List<GetWeaponDto> Weapons { get; set; } = null!;
}
