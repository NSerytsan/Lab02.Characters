using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Data;

[Table(("Character"))]
public class Character
{
    public Character()
    {
        Skills = new HashSet<Skill>();
    }

    [Key]
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public int BiographyId { get; set; }
    public string Name { get; set; } = null!;
    public int HealthPoints { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public string Biography { get; set; } = null!;
    public virtual ICollection<Skill> Skills { get; set; }
    public virtual Weapon Weapon { get; set; } = null!;
}