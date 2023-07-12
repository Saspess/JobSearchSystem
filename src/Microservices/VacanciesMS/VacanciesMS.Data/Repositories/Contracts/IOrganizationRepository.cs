using VacanciesMS.Data.Entities;

namespace VacanciesMS.Data.Repositories.Contracts
{
    public interface IOrganizationRepository : IBaseRepository<OrganizationEntity>
    {
        Task<OrganizationEntity?> GetByEmailAsync(string email);
    }
}
