using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Dtos.Character;

public class OnlyCharacterDto : BaseCharacterDto
{
    [Required]
    public int Id { get; set; }
}
