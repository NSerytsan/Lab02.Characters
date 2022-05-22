using System.ComponentModel.DataAnnotations;
using Lab02.Characters.Models.Validators;

namespace Lab02.Characters.Models.Dtos.Character;

public class CreateCharacterDto : BaseCharacterDto
{
    [Required]
    [MinLength(1, ErrorMessage = "Треба хоч одна навичка")]
    public List<int> SkillIds { get; set; } = null!;
}
