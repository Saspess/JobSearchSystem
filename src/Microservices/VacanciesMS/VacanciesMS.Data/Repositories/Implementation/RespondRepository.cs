using VacanciesMS.Data.Contexts.Contracts;
using VacanciesMS.Data.Entities;
using VacanciesMS.Data.Repositories.Contracts;

namespace VacanciesMS.Data.Repositories.Implementation
{
    public class RespondRepository : BaseRepository<RespondEntity>, IRespondRepository
    {
        public RespondRepository(IApplicationDbContext appContext) : base(appContext) { }
    }
}
