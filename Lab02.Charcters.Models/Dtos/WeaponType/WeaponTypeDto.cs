using Lab02.Characters.Models.Dtos.Weapon;

namespace Lab02.Characters.Models.Dtos.WeaponType;

public class WeaponTypeDto : BaseWeaponTypeDto
{
    public int Id { get; set; }
    public IEnumerable<OnlyWeaponDto> Weapons { get; set; } = null!;
}
