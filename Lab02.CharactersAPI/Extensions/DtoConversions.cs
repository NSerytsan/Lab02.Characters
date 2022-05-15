using Lab02.CharactersAPI.Dtos.Character;
using Lab02.CharactersAPI.Dtos.Skill;
using Lab02.CharactersAPI.Dtos.Weapon;
using Lab02.CharactersAPI.Dtos.WeaponType;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Extensions;

public static class DtoConversions
{
    // Character
    public static IEnumerable<CharacterDto> ConvertToDto(this IEnumerable<Character> characters)
    {
        return from character in characters
               select character.ConvertToDto();
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
                     },
            Weapon = character.Weapon.ConvertToDto()
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

    public static WeaponTypeDto ConvertToDto(this WeaponType weaponType)
    {
        var weapons = from weapon in weaponType.Weapons
                      select new GetWeaponDto
                      {
                          Id = weapon.Id,
                          Name = weapon.Name,
                          Attack = weapon.Attack
                      };

        return new WeaponTypeDto()
        {
            Id = weaponType.Id,
            Name = weaponType.Name,
            Weapons = weapons.ToList()
        };
    }

    //Weapon
    public static IEnumerable<GetWeaponDto> ConvertToDto(this IEnumerable<Weapon> weapons)
    {
        return from weapon in weapons
               select new GetWeaponDto
               {
                   Id = weapon.Id,
                   Name = weapon.Name,
                   Attack = weapon.Attack,
                   WeaponTypeId = weapon.WeaponTypeId
               };
    }

    public static WeaponDto ConvertToDto(this Weapon weapon)
    {
        var weaponType = new GetWeaponTypeDto()
        {
            Id = weapon.WeaponType.Id,
            Name = weapon.WeaponType.Name
        };

        return new WeaponDto()
        {
            Id = weapon.Id,
            Name = weapon.Name,
            Attack = weapon.Attack,
            WeaponTypeId = weapon.WeaponTypeId,
            WeaponType = weaponType
        };
    }
}
