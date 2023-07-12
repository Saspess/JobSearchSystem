using AutoMapper;
using IdentityMS.Business.MappingProfiles;

namespace IdentityMS.Tests.UnitTests.MappingTests
{
    public class UserMappingTests
    {
        [Fact]
        public void ValidateUserMappingProfile_ShouldReturnSuccessResult()
        {
            var mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
