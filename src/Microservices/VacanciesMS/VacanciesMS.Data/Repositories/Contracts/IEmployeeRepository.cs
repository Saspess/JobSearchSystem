using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Repositories.Contracts
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
    {
        Task<EmployeeEntity?> GetByEmailAsync(string email);
    }
}
