using AccountsMS.Business.DTOs.Skill;

namespace AccountsMS.Business.Services.Contracts
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillViewDto>> GetAllSkillsAsync();
        Task<SkillViewDto?> GetSkillById(int id);
        Task<SkillViewDto?> CreateSkillAsync(SkillCreateDto skillCreateDto);
        Task UpdateSkillAsync(SkillUpdateDto skillUpdateDto);
        Task DeleteSkillAsync(int id);
    }
}
