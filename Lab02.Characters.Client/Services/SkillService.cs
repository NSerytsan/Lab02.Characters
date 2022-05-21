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
    public async Task<SkillDto> AddAsync(CreateSkillDto skill)
    {
        var response = await _httpClient.PostAsJsonAsync<CreateSkillDto>("api/Skill", skill);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<SkillDto>();
            return result ?? new SkillDto();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status:{response.StatusCode} Message -{message}");
        }
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

    public async Task<SkillDto> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Skill/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<SkillDto>();
            return result ?? new SkillDto();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }

    public async Task UpdateAsync(UpdateSkillDto skill)
    {
        var response = await _httpClient.PutAsJsonAsync<UpdateSkillDto>($"api/Skill/{skill.Id}", skill);
    }
}
