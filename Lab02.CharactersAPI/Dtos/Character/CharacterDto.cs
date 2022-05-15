using Lab02.CharactersAPI.Dtos.Skill;
using Lab02.CharactersAPI.Dtos.Weapon;
using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Character;

public class CharacterDto : BaseCharacterDto
{
    [Required]
    public int Id { get; set; }
    public IEnumerable<GetSkillDto> Skills { get; set; } = null!;
    public WeaponDto Weapon { get; set; } = null!;
}
