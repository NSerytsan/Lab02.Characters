using System.ComponentModel.DataAnnotations;
using Lab02.CharactersAPI.Dtos.Character;

namespace Lab02.CharactersAPI.Dtos.Skill;

public class SkillDto : BaseSkillDto
{
    [Required]
    public int Id { get; set; }
    public IEnumerable<GetCharacterDto> Characters {get; set;} = null!;
}
