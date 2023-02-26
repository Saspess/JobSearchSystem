using Microsoft.Extensions.Configuration;

namespace AccountsMS.Data.Repositories.Implementation
{
    public abstract class BaseRepository
    {
        protected readonly string connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("sqlDbConnection");
        }
    }
}
