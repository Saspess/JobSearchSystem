using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.MessageHandlers;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Business.Services.Implementation;
using FluentValidation;
using Kafka.IoC;
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

        public static IServiceCollection ConfigureConsumers(this IServiceCollection services)
        {
            services.AddKafkaConsumer<string, EmployeeMessageDto, EmployeeMessageHandler>(p =>
            {
                p.Topic = "Employees";
                p.GroupId = "EmployeesGroup";
                p.BootstrapServers = "broker:29092";

                p.AllowAutoCreateTopics = true;
            });

            services.AddKafkaConsumer<string, OrganizationMessageDto, OrganizationMessageHandler>(p =>
            {
                p.Topic = "Organizations";
                p.GroupId = "OrganizationsGroup";
                p.BootstrapServers = "broker:29092";

                p.AllowAutoCreateTopics = true;
            });

            return services;
        }
    }
}
