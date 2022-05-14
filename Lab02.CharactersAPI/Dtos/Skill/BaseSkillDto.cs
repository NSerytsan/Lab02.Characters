using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Skill;

public abstract class BaseSkillDto
{
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
