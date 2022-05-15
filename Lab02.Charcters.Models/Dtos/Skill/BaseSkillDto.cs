using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Skill;

public abstract class BaseSkillDto
{
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
