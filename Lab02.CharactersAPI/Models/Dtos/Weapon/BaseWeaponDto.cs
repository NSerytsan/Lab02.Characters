using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Models.Dtos.Weapon;

public abstract class BaseWeaponDto
{
    [Required]
    public int WeaponTypeId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Attack { get; set; }
}
