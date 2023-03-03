using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;

namespace AccountsMS.Business.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewDto>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeViewDto>> GetEmployeesAsync(string skillName);
        Task<IEnumerable<EmployeeSkillViewDto>> GetAllEmployeeSkillsAsync();
        Task<EmployeeViewDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeViewDto?> GetEmployeeByEmailAsync(string email);
        Task<EmployeeViewDto?> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task AddEmployeeSkillAsync(int employeeId, int skillId);
        Task UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto);
        Task ConfirmEmployeeSkillAsync(int employeeId, int skillId);
        Task DeleteEmployeeAsync(int id);
        Task DeleteEmployeeSkillAsync(int employeeId, int skillId);
    }
}
