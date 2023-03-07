using AccountsMS.Business.Services.Contracts;
using AccountsMS.Business.Services.Implementation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AccountsMS.Business.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ISkillService, SkillService>();

            return services;
        }
    }
}
