using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Models;

[Table("Weapon")]
public class Weapon
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int WeaponTypeId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Attack { get; set; }
    public WeaponType WeaponType { get; set; } = null!;
}
