using AutoMapper;
using Lab02.CharactersAPI.Dtos.Weapon;
using Lab02.CharactersAPI.Dtos.WeaponTypes;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Helpers;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Weapon, CreateWeaponDto>().ReverseMap();
        CreateMap<Weapon, WeaponDto>().ReverseMap();

        CreateMap<WeaponType, CreateWeaponTypeDto>().ReverseMap();
        CreateMap<WeaponType, GetWeaponTypeDto>().ReverseMap();
        CreateMap<WeaponType, WeaponTypeDto>().ReverseMap();
    }
}
