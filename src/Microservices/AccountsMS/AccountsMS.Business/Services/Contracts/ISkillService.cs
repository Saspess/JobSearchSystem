using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Response.Generic;
using AccountsMS.Business.Response.NonGeneric;

namespace AccountsMS.Business.Services.Contracts
{
    public interface ISkillService
    {
        Task<Result<IEnumerable<SkillViewDto>>> GetAllSkillsAsync();
        Task<Result<SkillViewDto>> GetSkillByIdAsync(int id);
        Task<Result<SkillViewDto>> CreateSkillAsync(SkillCreateDto skillCreateDto);
        Task<Result> UpdateSkillAsync(SkillUpdateDto skillUpdateDto);
        Task<Result> DeleteSkillAsync(int id);
    }
}
