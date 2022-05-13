using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Models;

[Table(("Character"))]
public class Character
{
    [Key]
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public int BiographyId { get; set; }
    public string Name { get; set; } = null!;
    public int HealthPoints { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public string Biography { get; set; } = null!;
    public virtual ICollection<Skill> Skills { get; set; } = null!;
    public virtual Weapon Weapon { get; set; } = null!;
}