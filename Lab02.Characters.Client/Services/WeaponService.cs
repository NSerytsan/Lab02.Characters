using System.Net.Http.Json;
using Lab02.Characters.Client.Services.Contracts;
using Lab02.Characters.Models.Dtos.Weapon;

namespace Lab02.Characters.Client.Services;

public class WeaponService : IWeaponService
{
    private readonly HttpClient _httpClient;

    public WeaponService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeaponDto> AddAsync(CreateWeaponDto weapon)
    {
        var response = await _httpClient.PostAsJsonAsync<CreateWeaponDto>("api/Weapon", weapon);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<WeaponDto>();
            return result ?? new WeaponDto();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status:{response.StatusCode} Message -{message}");
        }
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WeaponDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/Weapon");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<WeaponDto>();
            }
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<WeaponDto>>();
            return result ?? Enumerable.Empty<WeaponDto>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        }
    }

    public Task<WeaponDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateWeaponDto weaponType)
    {
        throw new NotImplementedException();
    }
}
