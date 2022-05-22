using Lab02.Characters.Models.Dtos.Character;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Skill;

public class SkillDto : BaseSkillDto
{
    [Required]
    public int Id { get; set; }
    public IEnumerable<OnlyCharacterDto> Characters { get; set; } = null!;
}
