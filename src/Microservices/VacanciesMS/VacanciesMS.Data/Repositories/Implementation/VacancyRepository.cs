using VacanciesMS.Data.Contexts.Contracts;
using VacanciesMS.Data.Entities;
using VacanciesMS.Data.Repositories.Contracts;

namespace VacanciesMS.Data.Repositories.Implementation
{
    public class VacancyRepository : BaseRepository<VacancyEntity>, IVacancyRepository
    {
        public VacancyRepository(IApplicationDbContext appContext) : base(appContext) { }
    }
}
