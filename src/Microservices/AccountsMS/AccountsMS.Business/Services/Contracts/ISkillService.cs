using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Responce.NonGeneric;

namespace AccountsMS.Business.Services.Contracts
{
    public interface ISkillService
    {
        Task<Result> GetAllSkillsAsync();
        Task<Result> GetSkillByIdAsync(int id);
        Task<Result> CreateSkillAsync(SkillCreateDto skillCreateDto);
        Task<Result> UpdateSkillAsync(SkillUpdateDto skillUpdateDto);
        Task<Result> DeleteSkillAsync(int id);
    }
}
