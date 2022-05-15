using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Weapon;

public class GetWeaponDto : BaseWeaponDto
{
    [Required]
    public int Id { get; set; }
}
