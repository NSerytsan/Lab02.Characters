using System.ComponentModel.DataAnnotations;
using Lab02.CharactersAPI.Dtos.Skill;

namespace Lab02.CharactersAPI.Dtos.Character;

public class GetCharacterDto : BaseCharacterDto
{
    [Required]
    public int Id { get; set; }
    public IEnumerable<SkillIdDto> Skills {get; set;} = null!;
}
