using System.ComponentModel.DataAnnotations;

namespace Lab02.CharactersAPI.Dtos.Character;

public class GetCharacterDto : BaseCharacterDto
{
    [Required]
    public int Id { get; set; }
}
