using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Skill;

public class UpdateSkillDto : BaseSkillDto
{
    [Required]
    public int Id { get; set; }
}
