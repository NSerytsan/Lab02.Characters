using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Skill;

public class GetSkillDto : BaseSkillDto
{
    [Required]
    public int Id { get; set; }
}
