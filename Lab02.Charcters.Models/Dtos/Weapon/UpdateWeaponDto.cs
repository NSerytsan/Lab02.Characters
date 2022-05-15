using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Weapon;

public class UpdateWeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }
}
