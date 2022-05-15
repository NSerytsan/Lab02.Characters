namespace Lab02.CharactersAPI.Dtos.Character;

public class CreateCharacterDto : BaseCharacterDto
{
    public IEnumerable<int> Skills { get; set; } = null!;
}
