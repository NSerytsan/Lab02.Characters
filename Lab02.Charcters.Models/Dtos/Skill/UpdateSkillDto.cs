using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Skill;

public class UpdateSkillDto : BaseSkillDto
{
    [Required]
    public int Id { get; set; }
}
