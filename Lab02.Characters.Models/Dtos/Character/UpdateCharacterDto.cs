using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Character;

public class UpdateCharacterDto : BaseCharacterDto
{
    public int Id { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "Треба хоч одна навичка")]
    public List<int> SkillIds { get; set; } = null!;
}
