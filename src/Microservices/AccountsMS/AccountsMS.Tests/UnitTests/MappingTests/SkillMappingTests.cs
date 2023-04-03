using AccountsMS.Business.MappingProfiles;
using AutoMapper;

namespace AccountsMS.Tests.UnitTests.MappingTests
{
    public class SkillMappingTests
    {
        [Fact]
        public void ValidateSkillMappingProfile_ShouldReturnSuccessResult()
        {
            var mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new SkillMappingProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
