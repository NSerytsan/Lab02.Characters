using Lab02.Characters.Client.Services.Contracts;
using Lab02.Characters.Models.Dtos.Character;
using System.Net.Http.Json;

namespace Lab02.Characters.Client.Services;

public class CharacterService : ICharacterService
{
    private readonly HttpClient _httpClient;

    public CharacterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<CharacterDto> AddAsync(CreateCharacterDto character)
    {
        var response = await _httpClient.PostAsJsonAsync<CreateCharacterDto>("api/Character", character);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<CharacterDto>();
            return result ?? new CharacterDto();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status:{response.StatusCode} Message -{message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Character/{id}");
    }

    public async Task<IEnumerable<CharacterDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/Character");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<CharacterDto>();
            }
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<CharacterDto>>();
            return result ?? Enumerable.Empty<CharacterDto>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }

    public async Task<CharacterDto> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Character/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<CharacterDto>();
            return result ?? new CharacterDto();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }

    public async Task UpdateAsync(UpdateCharacterDto character)
    {
        var response = await _httpClient.PutAsJsonAsync<UpdateCharacterDto>($"api/Character/{character.Id}", character);
    }
}
