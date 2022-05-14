namespace Lab02.CharactersAPI.Dtos.Character;

public class CreateCharacterDto : BaseCharacterDto
{
    public IEnumerable<SkillIdDto> Skills { get; set; } = null!;
}
