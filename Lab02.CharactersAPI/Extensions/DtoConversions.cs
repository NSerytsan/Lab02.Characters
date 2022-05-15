using Lab02.CharactersAPI.Dtos.Character;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Extensions;

public static class DtoConversions
{
    public static IEnumerable<GetCharacterDto> ConvertToDto(this IEnumerable<Character> characters)
    {
        return (from character in characters
                select new GetCharacterDto()
                {
                    Id = character.Id,
                    Name = character.Name,
                    HealthPoints = character.HealthPoints,
                    Attack = character.Attack,
                    Defense = character.Defense,
                    Biography = character.Biography,
                    WeaponId = character.WeaponId,
                    Skills = from skill in character.Skills
                             select skill.Id
                }).ToList();
    }

    public static CharacterDto ConvertToDto(this Character character)
    {
        return new CharacterDto()
        {
            Id = character.Id,
            Name = character.Name,
            HealthPoints = character.HealthPoints,
            Attack = character.Attack,
            Defense = character.Defense,
            Biography = character.Biography,
            WeaponId = character.WeaponId
        };
    }
}
