using IdentityMS.Data.Contexts.Contracts;
using IdentityMS.Data.Entities;
using IdentityMS.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IdentityMS.Data.Repositories.Implementation
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email) =>
            await appContext.Set<UserEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == email);
    }
}
