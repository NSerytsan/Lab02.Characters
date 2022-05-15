using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Character;

public class BaseCharacterDto
{
    public int WeaponId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int HealthPoints { get; set; }
    [Required]
    public int Attack { get; set; }
    [Required]
    public int Defense { get; set; }
    public string Biography { get; set; } = null!;
}
