using FluentValidation;
using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.Services.Contracts;
using IdentityMS.Business.Services.Implementation;
using Kafka.IoC;
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

        public static IServiceCollection ConfigureProducers(this IServiceCollection services)
        {
            services.AddKafkaProducer<string, EmployeeMessageDto>(p =>
            {
                p.Topic = "Employees";
                p.BootstrapServers = "broker:29092";
            });

            services.AddKafkaProducer<string, OrganizationMessageDto>(p =>
            {
                p.Topic = "Organizations";
                p.BootstrapServers = "broker:29092";
            });

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
