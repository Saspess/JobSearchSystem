using AutoMapper;
using IdentityMS.Business.DTOs.Enums;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Business.Exceptions;
using IdentityMS.Data.Contexts.Implementation;
using IdentityMS.Data.Entities;
using IdentityMS.Data.Repositories.Contracts;
using IdentityMS.Data.Repositories.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityMS.Business.SeedData
{
    public static class DataSeeder
    {
        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var userRepository = services.GetService<IUserRepository>() ?? throw new ServiceNotFoundException("User repository was not found.");
            var mapper = services.GetService<IMapper>() ?? throw new ServiceNotFoundException("Mapper was not found.");

            var userRegisterDto = new UserRegisterDto()
            {
                Email = "jssadmin@gmail.com",
                Password = "adminPass123",
                Role = Roles.Admin
            };

            var existedAdmin = await userRepository.GetUserByEmailAsync(userRegisterDto.Email);

            if(existedAdmin == null)
            {
                var userEntity = mapper.Map<UserEntity>(userRegisterDto);
                await userRepository.CreateUserAsync(userEntity);
            }

            return app;
        }
    }
}
