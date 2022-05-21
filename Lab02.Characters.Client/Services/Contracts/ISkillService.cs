using Lab02.Characters.Models.Dtos.Skill;

namespace Lab02.Characters.Client.Services.Contracts;

public interface ISkillService
{
    Task<IEnumerable<SkillDto>> GetAllAsync();
    Task<SkillDto> GetAsync(int id);
    Task<SkillDto> AddAsync(CreateSkillDto skill);
    Task UpdateAsync(UpdateSkillDto skill);
    Task DeleteAsync(int id);
}
