using System.ComponentModel.DataAnnotations;
using Lab02.CharactersAPI.Dtos.WeaponType;

namespace Lab02.CharactersAPI.Dtos.Weapon;

public class WeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }

    public GetWeaponTypeDto WeaponType { get; set; } = null!;
}
