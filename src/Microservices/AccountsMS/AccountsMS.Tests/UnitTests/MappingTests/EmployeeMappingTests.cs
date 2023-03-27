using AccountsMS.Business.MappingProfiles;
using AutoMapper;

namespace AccountsMS.Tests.UnitTests.MappingTests
{
    public class EmployeeMappingTests
    {
        [Fact]
        public void ValidateEmployeeMappingProfile_ShouldReturnSuccessResult()
        {
            var mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new EmployeeMappingProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}