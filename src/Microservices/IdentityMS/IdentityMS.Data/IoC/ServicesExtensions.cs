using IdentityMS.Data.Contexts.Contracts;
using IdentityMS.Data.Contexts.Implementation;
/*using IdentityMS.Data.Repositories.Contracts;
using IdentityMS.Data.Repositories.Implementation;*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityMS.Data.IoC
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlDbConnection")),
            ServiceLifetime.Transient);
        }

        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }
        /*
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }*/
    }
}
