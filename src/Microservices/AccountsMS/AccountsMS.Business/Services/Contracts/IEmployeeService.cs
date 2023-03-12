using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.Response.NonGeneric;

namespace AccountsMS.Business.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<Result> GetAllEmployeesAsync();
        Task<Result> GetEmployeesBySkillNameAsync(string skillName);
        Task<Result> GetAllEmployeeSkillsAsync(int id);
        Task<Result> GetEmployeeByIdAsync(int id);
        Task<Result> GetEmployeeByEmailAsync(string email);
        Task<Result> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task<Result> AddEmployeeSkillAsync(int employeeId, int skillId);
        Task<Result> UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto);
        Task<Result> ConfirmEmployeeSkillAsync(int employeeId, int skillId);
        Task<Result> DeleteEmployeeAsync(int id);
        Task<Result> DeleteEmployeeSkillAsync(int employeeId, int skillId);
    }
}
