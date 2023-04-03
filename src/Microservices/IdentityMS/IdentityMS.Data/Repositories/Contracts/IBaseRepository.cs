using IdentityMS.Data.Entities;

namespace IdentityMS.Data.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllUsersAsync();
        Task<TEntity?> GetUserByIdAsync(int id);
        Task<TEntity> CreateUserAsync(TEntity entity);
        Task UpdateUserAsync(TEntity entity);
        Task DeleteUserAsync(int id);
    }
}
