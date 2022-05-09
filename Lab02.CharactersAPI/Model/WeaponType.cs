using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Model;

[Table("WeaponType")]
public class WeaponType
{
    public WeaponType()
    {
        Weapons = new HashSet<Weapon>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Weapon> Weapons { get; set; }
}
