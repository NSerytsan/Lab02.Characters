using Lab02.CharactersAPI.Dtos.Character;
using Lab02.CharactersAPI.Dtos.Skill;
using Lab02.CharactersAPI.Dtos.WeaponType;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Extensions;

public static class DtoConversions
{
    // Character
    public static IEnumerable<GetCharacterDto> ConvertToDto(this IEnumerable<Character> characters)
    {
        return from character in characters
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
               };
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
            WeaponId = character.WeaponId,
            Skills = from skill in character.Skills
                     select new GetSkillDto()
                     {
                         Id = skill.Id,
                         Name = skill.Name,
                         Description = skill.Description
                     }
        };
    }

    public static Character ConvertFromDto(this CreateCharacterDto createCharacterDto, IEnumerable<Skill> skills)
    {
        var character = new Character()
        {
            Name = createCharacterDto.Name,
            HealthPoints = createCharacterDto.HealthPoints,
            Attack = createCharacterDto.Attack,
            Defense = createCharacterDto.Defense,
            WeaponId = createCharacterDto.WeaponId,
            Biography = createCharacterDto.Biography,
            Skills = new HashSet<Skill>()
        };

        foreach (var skillId in createCharacterDto.Skills)
        {
            var skill = skills.FirstOrDefault(s => s.Id == skillId);
            if (skill != null)
            {
                character.Skills.Add(skill);
            }
        }

        return character;
    }

    //WeaponType
    public static IEnumerable<GetWeaponTypeDto> ConvertToDto(this IEnumerable<WeaponType> weaponTypes)
    {
        return from weaponType in weaponTypes
               select new GetWeaponTypeDto
               {
                   Id = weaponType.Id,
                   Name = weaponType.Name
               };
    }
}
