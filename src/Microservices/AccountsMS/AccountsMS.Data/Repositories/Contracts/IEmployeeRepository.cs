using AccountsMS.Data.Models.Employee;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel?> GetEmployeeByIdAsync(int id);
        Task<EmployeeModel?> GetEmployeeByEmailAsync(string email);
        Task CreateEmployeeAsync(EmployeeCreateModel employeeCreateModel);
        Task UpdateEmployeeAsync(EmployeeUpdateModel employeeUpdateModel);
        Task DeleteEmployeeAsync(int id);
    }
}
