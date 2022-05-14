using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Weapon;

public class WeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }
}
