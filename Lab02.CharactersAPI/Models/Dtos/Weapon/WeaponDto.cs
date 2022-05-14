using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Models.Dtos.Weapon;

public class WeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }
}
