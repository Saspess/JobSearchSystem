using Microsoft.EntityFrameworkCore;
using VacanciesMS.Data.Contexts.Contracts;
using VacanciesMS.Data.Entities;
using VacanciesMS.Data.Repositories.Contracts;

namespace VacanciesMS.Data.Repositories.Implementation
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(IApplicationDbContext appContext) : base(appContext) { }

        public async Task<EmployeeEntity?> GetByEmailAsync(string email) =>
            await appContext.Set<EmployeeEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Email == email);
    }
}
