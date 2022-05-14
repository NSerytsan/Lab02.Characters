using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Models.Dtos.WeaponType;

public abstract class BaseWeaponTypeDto
{
    [Required]
    public string Name { get; set; } = null!;
}
