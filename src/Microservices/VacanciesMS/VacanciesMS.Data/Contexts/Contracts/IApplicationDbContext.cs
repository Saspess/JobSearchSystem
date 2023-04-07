using Microsoft.EntityFrameworkCore;
using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Contexts.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<OrganizationEntity> Organizations { get; set; }
        DbSet<VacancyEntity> Vacancies { get; set; }
        DbSet<RespondEntity> Responds { get; set; }
        DbSet<EmployeeEntity> Employees { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
