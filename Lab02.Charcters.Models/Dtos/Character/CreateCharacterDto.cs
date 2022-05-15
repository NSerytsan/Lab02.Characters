namespace Lab02.Characters.Models.Dtos.Character;

public class CreateCharacterDto : BaseCharacterDto
{
    public IEnumerable<int> Skills { get; set; } = null!;
}
