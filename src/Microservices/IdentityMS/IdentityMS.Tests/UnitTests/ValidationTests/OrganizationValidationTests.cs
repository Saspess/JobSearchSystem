using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.Validators;

namespace IdentityMS.Tests.UnitTests.ValidationTests
{
    public class OrganizationValidationTests
    {
        private readonly OrganizationRegisterDtoValidator _organizationRegisterDtoValidator;

        public OrganizationValidationTests()
        {
            _organizationRegisterDtoValidator = new OrganizationRegisterDtoValidator();
        }

        [Theory]
        [InlineData("Soft", "Minsk", "soft@gmail.com", "Pass1234", true)]
        [InlineData("", "Minsk", "soft@gmail.com", "Pass1234", false)]
        [InlineData(null, "Minsk", "soft@gmail.com", "Pass1234", false)]
        [InlineData("Soft", "", "soft@gmail.com", "Pass1234", false)]
        [InlineData("Soft", null, "soft@gmail.com", "Pass1234", false)]
        [InlineData("Soft", "Minsk", "", "Pass1234", false)]
        [InlineData("Soft", "Minsk", null, "Pass1234", false)]
        [InlineData("Soft", "Minsk", "sometext", "Pass1234", false)]
        [InlineData("Soft", "Minsk", "soft@gmail.com", null, false)]
        [InlineData("Soft", "Minsk", "soft@gmail.com", "", false)]
        [InlineData("Soft", "Minsk", "soft@gmail.com", "Pass123", false)]
        [InlineData("Soft", "Minsk", "soft@gmail.com", "pass1234", false)]
        [InlineData("Soft", "Minsk", "soft@gmail.com", "Passpass", false)]
        [InlineData("Soft", "Minsk", "soft@gmail.com", "PASS1234", false)]
        public void OrganizationRegisterDtoValidatorTests(
            string name,
            string hometown,
            string email,
            string password,
            bool isValid)
        {
            var organizationRegisterDto = new OrganizationRegisterDto()
            {
                Name = name,
                Hometown = hometown,
                Email = email,
                Password = password
            };

            Assert.Equal(isValid, _organizationRegisterDtoValidator.Validate(organizationRegisterDto).IsValid);
        }
    }
}
