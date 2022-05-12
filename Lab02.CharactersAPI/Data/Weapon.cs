using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Data;

[Table("Weapon")]
public class Weapon
{
    [Key]
    public int Id { get; set; }
    public int WeaponTypeId { get; set; }
    public string Name { get; set; } = null!;
    public int Attack { get; set; }
    public WeaponType WeaponType { get; set; } = null!;
}