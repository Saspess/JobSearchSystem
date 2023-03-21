using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;
using AccountsMS.Business.Response.Generic;
using AccountsMS.Business.Response.NonGeneric;

namespace AccountsMS.Business.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<Result<IEnumerable<EmployeeViewDto>>> GetAllEmployeesAsync();
        Task<Result<IEnumerable<EmployeeViewDto>>> GetEmployeesBySkillNameAsync(string skillName);
        Task<Result<IEnumerable<EmployeeSkillViewDto>>> GetAllEmployeeSkillsAsync(int id);
        Task<Result<EmployeeViewDto>> GetEmployeeByIdAsync(int id);
        Task<Result<EmployeeViewDto>> GetEmployeeByEmailAsync(string email);
        Task<Result<EmployeeViewDto>> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task<Result> AddEmployeeSkillAsync(EmployeeSkillDto employeeSkillDto);
        Task<Result> UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto);
        Task<Result> ConfirmEmployeeSkillAsync(EmployeeSkillDto employeeSkillDto);
        Task<Result> DeleteEmployeeAsync(int id);
        Task<Result> DeleteEmployeeSkillAsync(EmployeeSkillDto employeeSkillDto);
    }
}
