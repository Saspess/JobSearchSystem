using IdentityMS.Data.Contexts.Contracts;
using IdentityMS.Data.Entities;
using IdentityMS.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IdentityMS.Data.Repositories.Implementation
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected IApplicationDbContext appContext;

        public BaseRepository(IApplicationDbContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllUsersAsync() =>
           await appContext.Set<TEntity>()
           .AsNoTracking()
           .ToListAsync();

        public virtual async Task<TEntity?> GetUserByIdAsync(int id) =>
            await appContext.Set<TEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == id);

        public virtual async Task<TEntity> CreateUserAsync(TEntity entity)
        {
            var created = await appContext.Set<TEntity>().AddAsync(entity);
            await appContext.SaveChangesAsync();

            return created.Entity;
        }

        public virtual async Task UpdateUserAsync(TEntity entity)
        {
            appContext.Set<TEntity>().Update(entity);
            await appContext.SaveChangesAsync();
        }

        public virtual async Task DeleteUserAsync(int id)
        {
            var entity = await appContext.Set<TEntity>().FindAsync(id);

            appContext.Set<TEntity>().Remove(entity);
            await appContext.SaveChangesAsync();
        }
    }
}
