using AccountsMS.Data.Repositories.Contracts;
using AccountsMS.Data.Repositories.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace AccountsMS.Data.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeSkillRepository, EmployeeSkillRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            return services;
        }
    }
}
