using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.CharactersAPI.Model;

[Table("Skill")]
public class Skill
{
    public Skill()
    {
        Characters = new HashSet<Character>();
    }
    
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Character> Characters { get; set; }
}