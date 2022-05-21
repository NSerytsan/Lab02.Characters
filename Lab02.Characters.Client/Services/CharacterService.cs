using Lab02.Characters.Client.Services.Contracts;
using Lab02.Characters.Models.Dtos.Character;

namespace Lab02.Characters.Client.Services;

public class CharacterService : ICharacterService
{
    public Task<CharacterDto> AddAsync(CreateCharacterDto weaponType)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CharacterDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CharacterDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CharacterDto weaponType)
    {
        throw new NotImplementedException();
    }
}
