using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Validators;

namespace AccountsMS.Tests.UnitTests.ValidationTests
{
    public class OrganizationValidationTests
    {
        private readonly OrganizationCreateDtoValidator _organizationCreateDtoValidator;
        private readonly OrganizationUpdateDtoValidator _organizationUpdateDtoValidator;

        public OrganizationValidationTests()
        {
            _organizationCreateDtoValidator = new OrganizationCreateDtoValidator();
            _organizationUpdateDtoValidator = new OrganizationUpdateDtoValidator();
        }

        [Theory]
        [InlineData("John", "Minsk", "johndoe@gmail.com", true)]
        [InlineData("", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(null, "Minsk", "johndoe@gmail.com", false)]
        [InlineData("John", "", "johndoe@gmail.com", false)]
        [InlineData("John", null, "johndoe@gmail.com", false)]
        [InlineData("John", "Minsk", "", false)]
        [InlineData("John", "Minsk", null, false)]
        [InlineData("John", "Minsk", "sometext", false)]
        public void OrganizationCreateDtoValidatorTests(
            string name,
            string hometown,
            string email,
            bool isValid)
        {
            var organizationCreateDto = new OrganizationCreateDto()
            {
                Name = name,
                Hometown = hometown,
                Email = email
            };

            Assert.Equal(isValid, _organizationCreateDtoValidator.Validate(organizationCreateDto).IsValid);
        }

        [Theory]
        [InlineData(1, "John", "Minsk", "johndoe@gmail.com", true)]
        [InlineData(1, "", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, null, "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, "John", "", "johndoe@gmail.com", false)]
        [InlineData(1, "John", null, "johndoe@gmail.com", false)]
        [InlineData(1, "John", "Minsk", "", false)]
        [InlineData(1, "John", "Minsk", null, false)]
        [InlineData(1, "John", "Minsk", "sometext", false)]
        public void OrganizationUpdateDtoValidatorTests(
            int id,
            string name,
            string hometown,
            string email,
            bool isValid)
        {
            var organizationUpdateDto = new OrganizationUpdateDto()
            {
                Id = id,
                Name = name,
                Hometown = hometown,
                Email = email
            };

            Assert.Equal(isValid, _organizationUpdateDtoValidator.Validate(organizationUpdateDto).IsValid);
        }
    }
}
