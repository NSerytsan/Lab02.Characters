using System.ComponentModel.DataAnnotations;
using Lab02.CharactersAPI.Dtos.Skill;

namespace Lab02.CharactersAPI.Dtos.Character;

public class CharacterDto : BaseCharacterDto
{
    [Required]
    public int Id { get; set; }
    public IEnumerable<GetSkillDto> Skills {get; set;} = null!;
}
