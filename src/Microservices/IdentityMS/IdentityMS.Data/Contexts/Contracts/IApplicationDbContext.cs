using IdentityMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityMS.Data.Contexts.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
