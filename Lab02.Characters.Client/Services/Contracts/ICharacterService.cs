using Lab02.Characters.Models.Dtos.Character;

namespace Lab02.Characters.Client.Services.Contracts;

public interface ICharacterService
{
    Task<IEnumerable<CharacterDto>> GetAllAsync();
    Task<CharacterDto> GetAsync(int id);
    Task<CharacterDto> AddAsync(CreateCharacterDto weaponType);
    Task UpdateAsync(CharacterDto weaponType);
    Task DeleteAsync(int id);
}
