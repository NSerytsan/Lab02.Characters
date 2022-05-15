using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.WeaponType;

public class UpdateWeaponTypeDto : BaseWeaponTypeDto
{
    [Required]
    public int Id { get; set; }
}
