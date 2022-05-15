using Lab02.Characters.API.Entities;
using Lab02.Characters.Models.Dtos.Character;
using Lab02.Characters.Models.Dtos.Skill;
using Lab02.Characters.Models.Dtos.Weapon;
using Lab02.Characters.Models.Dtos.WeaponType;

namespace Lab02.Characters.API.Extensions;

public static class DtoConversions
{
    // Character
    public static IEnumerable<CharacterDto> ToCharacterDtos(this IEnumerable<Character> characters)
    {
        return from character in characters
               select character.ToCharacterDto();
    }

    public static IEnumerable<OnlyCharacterDto> ToOnlyCharacterDtos(this IEnumerable<Character> characters)
    {
        return from character in characters
               select character.ToOnlyCharacterDto();
    }

    public static CharacterDto ToCharacterDto(this Character character)
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
            Weapon = character.Weapon.ToWeaponDto()
        };
    }

    public static OnlyCharacterDto ToOnlyCharacterDto(this Character character)
    {
        return new OnlyCharacterDto()
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

    public static Character FromCreateCharacterDto(this CreateCharacterDto createCharacterDto, IEnumerable<Skill> skills)
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

        foreach (var skillId in createCharacterDto.SkillIds)
        {
            var skill = skills.FirstOrDefault(s => s.Id == skillId);
            if (skill != null)
            {
                character.Skills.Add(skill);
            }
        }

        return character;
    }

    // Skill
    public static IEnumerable<SkillDto> ToSkillDtos(this IEnumerable<Skill> skills)
    {
        return from skill in skills
               select skill.ToSkillDto();
    }

    public static SkillDto ToSkillDto(this Skill skill)
    {
        return new SkillDto()
        {
            Id = skill.Id,
            Name = skill.Name,
            Description = skill.Description,
            Characters = skill.Characters.ToOnlyCharacterDtos()
        };
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

    public static WeaponTypeDto ToWeaponDto(this WeaponType weaponType)
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

    public static WeaponDto ToWeaponDto(this Weapon weapon)
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
