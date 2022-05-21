using System.Net.Http.Json;
using Lab02.Characters.Client.Services.Contracts;
using Lab02.Characters.Models.Dtos.Skill;

namespace Lab02.Characters.Client.Services;

public class SkillService : ISkillService
{
    private readonly HttpClient _httpClient;

    public SkillService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Task<SkillDto> AddAsync(CreateSkillDto weaponType)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/SKill/{id}");
    }

    public async Task<IEnumerable<SkillDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/Skill");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<SkillDto>();
            }

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<SkillDto>>();
            return result ?? Enumerable.Empty<SkillDto>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }

    public Task<SkillDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateSkillDto weaponType)
    {
        throw new NotImplementedException();
    }
}
