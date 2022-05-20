using Lab02.Characters.Client.Services.Contracts;
using Lab02.Characters.Models.Dtos.WeaponType;
using System.Net.Http.Json;

namespace Lab02.Characters.Client.Services;

public class WeaponTypeService : IWeaponTypeService
{
    private readonly HttpClient _httpClient;

    public WeaponTypeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeaponTypeDto> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/WeaponType/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<WeaponTypeDto>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }

    public async Task<IEnumerable<WeaponTypeDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/WeaponType");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<WeaponTypeDto>();
            }
            Console.WriteLine(response);
            return await response.Content.ReadFromJsonAsync<IEnumerable<WeaponTypeDto>>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }
}
