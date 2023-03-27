using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;
using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Data.Models.Employee;
using AccountsMS.Data.Models.EmployeeSkill;
using AccountsMS.Data.Models.Organization;
using AccountsMS.Data.Models.Skill;

namespace AccountsMS.Tests.UnitTests.ServicesTests
{
    public static class ServicesDataFactory
    {
        public static IEnumerable<EmployeeModel> GetAllEmployeesModels()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel()
                {
                    Id = 1,
                    OrganizationId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Hometown = "Minsk",
                    Email = "johndoe@gmail.com"
                },
                new EmployeeModel()
                {
                    Id = 2,
                    OrganizationId = 2,
                    FirstName = "Julia",
                    LastName = "Doe",
                    Hometown = "Minsk",
                    Email = "juliadoe@gmail.com"
                }
            };
        }

        public static IEnumerable<EmployeeViewDto> GetAllEmployeesViewDtos()
        {
            return new List<EmployeeViewDto>()
            {
                new EmployeeViewDto()
                {
                    Id = 1,
                    OrganizationId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Hometown = "Minsk",
                    Email = "johndoe@gmail.com"
                },
                new EmployeeViewDto()
                {
                    Id = 2,
                    OrganizationId = 2,
                    FirstName = "Julia",
                    LastName = "Doe",
                    Hometown = "Minsk",
                    Email = "juliadoe@gmail.com"
                }
            };
        }

        public static EmployeeViewDto GetEmployeeViewDto()
        {
            return new EmployeeViewDto()
            {
                Id = 1,
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Minsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static EmployeeUpdateDto GetEmployeeUpdateDto()
        {
            return new EmployeeUpdateDto()
            {
                Id = 1,
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Vitebsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static EmployeeCreateModel GetEmployeeCreateModel()
        {
            return new EmployeeCreateModel()
            {
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Vitebsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static EmployeeModel GetEmployeeModel()
        {
            return new EmployeeModel()
            {
                Id = 1,
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Minsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static EmployeeUpdateModel GetEmployeeUpdateModel()
        {
            return new EmployeeUpdateModel()
            {
                Id = 1,
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Vitebsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static EmployeeCreateDto GetEmployeeCreateDto()
        {
            return new EmployeeCreateDto()
            {
                OrganizationId = 1,
                FirstName = "John",
                LastName = "Doe",
                Hometown = "Vitebsk",
                Email = "johndoe@gmail.com"
            };
        }

        public static IEnumerable<EmployeeSkillModel> GetAllEmployeesSkillModels()
        {
            return new List<EmployeeSkillModel>()
            {
                new EmployeeSkillModel()
                {
                    Name = ".NET",
                    ConfirmationCount = 1
                },
                new EmployeeSkillModel()
                {
                    Name = "Git",
                    ConfirmationCount = 2
                }
            };
        }

        public static IEnumerable<EmployeeSkillViewDto> GetAllEmployeesSkillViewDtos()
        {
            return new List<EmployeeSkillViewDto>()
            {
                new EmployeeSkillViewDto()
                {
                    Name = ".NET",
                    ConfirmationCount = 1
                },
                new EmployeeSkillViewDto()
                {
                    Name = "Git",
                    ConfirmationCount = 2
                }
            };
        }

        public static EmployeeSkillDto GetEmployeeSkillDto()
        {
            return new EmployeeSkillDto()
            {
                EmployeeId = 1,
                SkillId = 1
            };
        }

        public static IEnumerable<OrganizationModel> GetAllOrganizationsModels()
        {
            return new List<OrganizationModel>()
            {
                new OrganizationModel()
                {
                    Id = 1,
                    Name = "BestSoft",
                    Email = "bestsoft@gmail.com",
                    Hometown = "Minsk"
                },
                new OrganizationModel()
                {
                    Id = 2,
                    Name = "NewSoft",
                    Email = "Newsoft@gmail.com",
                    Hometown = "Minsk"
                }
            };
        }

        public static IEnumerable<OrganizationViewDto> GetAllOrganizationsViewDtos()
        {
            return new List<OrganizationViewDto>()
            {
                new OrganizationViewDto()
                {
                    Id = 1,
                    Name = "BestSoft",
                    Email = "bestsoft@gmail.com",
                    Hometown = "Minsk"
                },
                new OrganizationViewDto()
                {
                    Id = 2,
                    Name = "NewSoft",
                    Email = "Newsoft@gmail.com",
                    Hometown = "Minsk"
                }
            };
        }

        public static OrganizationModel GetOrganizationModel()
        {
            return new OrganizationModel()
            {
                Id = 1,
                Name = "BestSoft",
                Email = "bestsoft@gmail.com",
                Hometown = "Minsk"
            };
        }

        public static OrganizationViewDto GetOrganizationViewDto()
        {
            return new OrganizationViewDto()
            {
                Id = 1,
                Name = "BestSoft",
                Email = "bestsoft@gmail.com",
                Hometown = "Minsk"
            };
        }

        public static OrganizationCreateModel GetOrganizationCreateModel()
        {
            return new OrganizationCreateModel()
            {
                Name = "BestSoft",
                Email = "bestsoft@gmail.com",
                Hometown = "Minsk"
            };
        }

        public static OrganizationCreateDto GetOrganizationCreateDto()
        {
            return new OrganizationCreateDto()
            {
                Name = "BestSoft",
                Email = "bestsoft@gmail.com",
                Hometown = "Minsk"
            };
        }

        public static OrganizationUpdateModel GetOrganizationUpdateModel()
        {
            return new OrganizationUpdateModel()
            {
                Id = 1,
                Name = "BestSoft",
                Email = "bestsoft@gmail.com",
                Hometown = "Minsk"
            };
        }

        public static OrganizationUpdateDto GetOrganizationUpdateDto()
        {
            return new OrganizationUpdateDto()
            {
                Id = 1,
                Name = "BestSoft",
                Email = "bestsoft@gmail.com",
                Hometown = "Minsk"
            };
        }

        public static IEnumerable<SkillModel> GetAllSkillsModels()
        {
            return new List<SkillModel>()
            {
                new SkillModel()
                {
                    Id = 1,
                    Name = ".NET"
                },
                new SkillModel()
                {
                    Id = 2,
                    Name = "Git"
                },
            };
        }

        public static IEnumerable<SkillViewDto> GetAllSkillsViewDtos()
        {
            return new List<SkillViewDto>()
            {
                new SkillViewDto()
                {
                    Id = 1,
                    Name = ".NET"
                },
                new SkillViewDto()
                {
                    Id = 2,
                    Name = "Git"
                },
            };
        }

        public static SkillModel GetSkillModel()
        {
            return new SkillModel()
            {
                Id = 1,
                Name = ".NET"
            };
        }

        public static SkillViewDto GetSkillViewDto()
        {
            return new SkillViewDto()
            {
                Id = 1,
                Name = ".NET"
            };
        }

        public static SkillCreateModel GetSkillCreateModel()
        {
            return new SkillCreateModel()
            {
                Name = ".NET"
            };
        }

        public static SkillCreateDto GetSkillCreateDto()
        {
            return new SkillCreateDto()
            {
                Name = ".NET"
            };
        }

        public static SkillUpdateModel GetSkillUpdateModel()
        {
            return new SkillUpdateModel()
            {
                Id = 1,
                Name = ".NET"
            };
        }

        public static SkillUpdateDto GetSkillUpdateDto()
        {
            return new SkillUpdateDto()
            {
                Id = 1,
                Name = ".NET"
            };
        }
    }
}
