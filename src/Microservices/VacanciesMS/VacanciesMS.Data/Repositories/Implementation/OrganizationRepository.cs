using Microsoft.EntityFrameworkCore;
using VacanciesMS.Data.Contexts.Contracts;
using VacanciesMS.Data.Entities;
using VacanciesMS.Data.Repositories.Contracts;

namespace VacanciesMS.Data.Repositories.Implementation
{
    public class OrganizationRepository : BaseRepository<OrganizationEntity>, IOrganizationRepository
    {
        public OrganizationRepository(IApplicationDbContext appContext) : base(appContext) { }

        public async Task<OrganizationEntity?> GetByEmailAsync(string email) =>
            await appContext.Set<OrganizationEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email == email);
    }
}
