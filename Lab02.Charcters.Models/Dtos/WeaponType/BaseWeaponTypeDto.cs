using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.WeaponType;

public abstract class BaseWeaponTypeDto
{
    [Required]
    public string Name { get; set; } = null!;
}
