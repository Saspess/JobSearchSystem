using AccountsMS.Data.Models.Employee;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeModel>> GetEmployeesBySkillNameAsync(string skillName);
        Task<EmployeeModel?> GetEmployeeByIdAsync(int id);
        Task<EmployeeModel?> GetEmployeeByEmailAsync(string email);
        Task<EmployeeModel?> CreateEmployeeAsync(EmployeeCreateModel employeeCreateModel);
        Task UpdateEmployeeAsync(EmployeeUpdateModel employeeUpdateModel);
        Task DeleteEmployeeAsync(int id);
    }
}
