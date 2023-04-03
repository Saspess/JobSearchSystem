using FluentValidation;
using IdentityMS.Business.Services.Contracts;
using IdentityMS.Business.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentityMS.Business.IoC
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
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
