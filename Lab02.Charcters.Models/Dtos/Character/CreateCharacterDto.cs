using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Character;

public class CreateCharacterDto : BaseCharacterDto
{
    public IEnumerable<int> SkillIds { get; set; } = null!;
}
