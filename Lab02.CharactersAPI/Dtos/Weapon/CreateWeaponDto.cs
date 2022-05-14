using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Weapon;

public class CreateWeaponDto : BaseWeaponDto
{
    [Required]
    public int WeaponTypeId { get; set; }
}
