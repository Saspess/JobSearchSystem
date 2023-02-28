using AccountsMS.Data.Models.Skill;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillModel>> GetAllSkillsAsync();
        Task<SkillModel?> GetSkillByIdAsync(int id);
        Task<SkillModel?> CreateSkillAsync(SkillCreateModel skillCreateModel);
        Task UpdateSkillAsync(SkillUpdateModel skillUpdateModel);
        Task DeleteSkillAsync(int id);
    }
}
