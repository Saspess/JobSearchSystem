using AccountsMS.Business.MappingProfiles;
using AutoMapper;

namespace AccountsMS.Tests.UnitTests.MappingTests
{
    public class OrganizationMappingTests
    {
        [Fact]
        public void ValidateOrganizationMappingProfile_ShouldReturnSuccessResult()
        {
            var mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new OrganizationMappingProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
