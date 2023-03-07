﻿using AccountsMS.Data.Models.EmployeeSkill;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface IEmployeeSkillRepository
    {
        Task<IEnumerable<EmployeeSkillModel>> GetAllEmployeeSkillsAsync(int employeeId);
        Task AddEmployeeSkillAsync(int employeeId, int skillId);
        Task ConfirmEmployeeSkillAsync(int employeeId, int skillId);
        Task DeleteEmployeeSkillAsync(int employeeId, int skillId);
    }
}
