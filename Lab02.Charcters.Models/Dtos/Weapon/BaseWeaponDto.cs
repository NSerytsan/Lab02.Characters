using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Weapon;

public abstract class BaseWeaponDto
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Attack { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int WeaponTypeId { get; set; }
}
