using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Models;

[Table("WeaponType")]
public class WeaponType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public virtual ICollection<Weapon> Weapons { get; set; } = null!;
}
