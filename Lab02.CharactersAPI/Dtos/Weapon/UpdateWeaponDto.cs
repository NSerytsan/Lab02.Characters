using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Weapon;

public class UpdateWeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int WeaponTypeId { get; set; }
}
