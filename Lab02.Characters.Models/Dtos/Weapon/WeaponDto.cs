using Lab02.Characters.Models.Dtos.WeaponType;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Weapon;

public class WeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }

    public OnlyWeaponTypeDto WeaponType { get; set; } = null!;
}
