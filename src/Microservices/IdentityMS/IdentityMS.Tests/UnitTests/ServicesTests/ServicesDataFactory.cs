using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Enums;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Data.Entities;

namespace IdentityMS.Tests.UnitTests.ServicesTests
{
    public static class ServicesDataFactory
    {
        public static IEnumerable<UserViewDto> GetAllUsersViewDtos()
        {
            return new List<UserViewDto>
            {
                new UserViewDto()
                {
                    Id = 1,
                    Email = "johndoe@gmail.com",
                    Role = Roles.Employee
                },
                new UserViewDto()
                {
                    Id = 2,
                    Email = "juliadoe@gmail.com",
                    Role = Roles.Employee
                }
            };
        }

        public static IEnumerable<UserEntity> GetAllUsersEntities()
        {
            return new List<UserEntity>
            {
                new UserEntity()
                {
                    Id = 1,
                    Email = "johndoe@gmail.com",
                    Password = "Pass1234",
                    Role = Roles.Employee.ToString()
                },
                new UserEntity()
                {
                    Id = 2,
                    Email = "juliadoe@gmail.com",
                    Password = "Pass1234",
                    Role = Roles.Employee.ToString()
                },
            };
        }

        public static UserViewDto GetUserViewDto()
        {
            return new UserViewDto()
            {
                Id = 1,
                Email = "juliadoe@gmail.com",
                Role = Roles.Employee
            };
        }

        public static UserEntity GetUserEntity()
        {
            return new UserEntity()
            {
                Id = 1,
                Email = "johndoe@gmail.com",
                Password = "Pass1234",
                Role = Roles.Employee.ToString()
            };
        }

        public static UserEntity GetUserEmployeeEntity()
        {
            return new UserEntity()
            {
                Id = 1,
                Email = "johndoe@gmail.com",
                Password = "Pass1234",
                Role = Roles.Employee.ToString()
            };
        }

        public static UserEntity GetUserOrganizationEntity()
        {
            return new UserEntity()
            {
                Id = 1,
                Email = "soft@gmail.com",
                Password = "Pass1234",
                Role = Roles.Organization.ToString()
            };
        }

        public static EmployeeRegisterDto GetEmployeeRegisterDto()
        {
            return new EmployeeRegisterDto
            {
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Minsk",
                Email = "johndoe@gmail.com",
                Password = "Pass1234"
            };
        }

        public static OrganizationRegisterDto GetOrganizationRegisterDto()
        {
            return new OrganizationRegisterDto
            {
                Name = "Soft",
                Hometown = "Minsk",
                Email = "soft@gmail.com",
                Password = "Pass1234"
            };
        }

        public static EmployeeMessageDto GetEmployeeMessageDto()
        {
            return new EmployeeMessageDto
            {
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Minsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static OrganizationMessageDto GetOrganizationMessageDto()
        {
            return new OrganizationMessageDto
            {
                Name = "Soft",
                Hometown = "Minsk",
                Email = "soft@gmail.com"
            };
        }

        public static UserUpdateDto GetUserUpdateDto() 
        {
            return new UserUpdateDto
            {
                Id = 1,
                Email = "johndoe@gmail.com",
                Password = "Pass1234",
                Role = Roles.Employee
            };
        }
    }
}

