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

    public Task<WeaponDto> AddAsync(CreateWeaponDto weaponType)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WeaponDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/WeaponType");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<WeaponDto>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<WeaponDto>>();
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
