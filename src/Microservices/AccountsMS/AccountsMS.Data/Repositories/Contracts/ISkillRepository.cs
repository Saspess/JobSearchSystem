using AccountsMS.Data.Models.Skill;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillViewModel>> GetAllSkillsAsync();
        Task<SkillViewModel?> GetSkillByIdAsync(int id);
        Task CreateSkillAsync(SkillCreateModel skillCreateModel);
        Task UpdateSkillAsync(SkillUpdateModel skillUpdateModel);
        Task DeleteSkillAsync(int id);
    }
}
