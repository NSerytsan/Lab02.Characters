using Lab02.Characters.Models.Dtos.Character;

namespace Lab02.Characters.Models.Extensions;

public static partial class DtoConversions
{
    public static UpdateCharacterDto ToUpdateCharacterDto(this CharacterDto character)
    {
        return new UpdateCharacterDto()
        {
            Id = character.Id,
            Name = character.Name,
            HealthPoints = character.HealthPoints,
            Attack = character.Attack,
            Defense = character.Defense,
            Biography = character.Biography,
            WeaponId = character.WeaponId,
            SkillIds = (from skill in character.Skills
                        select skill.Id).ToList()
        };
    }
}
