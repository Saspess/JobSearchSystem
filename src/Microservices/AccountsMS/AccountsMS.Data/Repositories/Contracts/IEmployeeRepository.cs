using AccountsMS.Data.Models.Employee;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();
        Task<EmployeeViewModel?> GetEmployeeByIdAsync(int id);
        Task<EmployeeViewModel?> GetEmployeeByEmailAsync(string email);
        Task CreateEmployeeAsync(EmployeeCreateModel employeeCreateModel);
        Task UpdateEmployeeAsync(EmployeeUpdateModel employeeUpdateModel);
        Task DeleteEmployeeAsync(int id);
    }
}
