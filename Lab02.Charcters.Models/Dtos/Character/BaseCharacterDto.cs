using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Character;

public class BaseCharacterDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Виберіть зброю") ]
    public int WeaponId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int HealthPoints { get; set; }
    [Required]
    public int Attack { get; set; }
    [Required]
    public int Defense { get; set; }
    [Required]
    public string Biography { get; set; } = null!;
}
