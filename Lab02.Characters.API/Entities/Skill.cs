using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.Characters.API.Entities;

[Table("Skill")]
public class Skill
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Character> Characters { get; set; } = null!;
}