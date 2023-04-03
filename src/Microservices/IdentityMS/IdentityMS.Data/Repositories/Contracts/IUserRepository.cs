using IdentityMS.Data.Entities;

namespace IdentityMS.Data.Repositories.Contracts
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity?> GetUserByEmailAsync(string email);
    }
}
