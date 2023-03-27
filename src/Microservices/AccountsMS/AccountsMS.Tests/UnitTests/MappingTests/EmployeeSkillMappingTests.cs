using AccountsMS.Business.MappingProfiles;
using AutoMapper;

namespace AccountsMS.Tests.UnitTests.MappingTests
{
    public class EmployeeSkillMappingTests
    {
        [Fact]
        public void ValidateEmployeeSkillMappingProfile_ShouldReturnSuccessResult()
        {
            var mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new EmployeeSkillMappingProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}