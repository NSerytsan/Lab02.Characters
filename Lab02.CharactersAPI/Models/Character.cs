using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Models;

[Table(("Character"))]
public class Character
{
    [Key]
    public int Id { get; set; }
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
    public virtual ICollection<Skill> Skills { get; set; } = null!;
    public virtual Weapon Weapon { get; set; } = null!;
}