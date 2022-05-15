using Lab02.CharactersAPI.Dtos.Character;
using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Skill;

public class SkillDto : BaseSkillDto
{
    [Required]
    public int Id { get; set; }
    public IEnumerable<GetCharacterDto> Characters { get; set; } = null!;
}
