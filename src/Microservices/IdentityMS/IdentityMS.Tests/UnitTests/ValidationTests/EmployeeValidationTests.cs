using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.Validators;

namespace IdentityMS.Tests.UnitTests.ValidationTests
{
    public class EmployeeValidationTests
    {
        private readonly EmployeeRegisterDtoValidator _employeeRegisterDtoValidator;

        public EmployeeValidationTests()
        {
            _employeeRegisterDtoValidator = new EmployeeRegisterDtoValidator();
        }

        [Theory]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "Pass1234", true)]
        [InlineData(1, "", "Doe", "Minsk", "johndoe@gmail.com", "Pass1234", false)]
        [InlineData(1, null, "Doe", "Minsk", "johndoe@gmail.com", "Pass1234", false)]
        [InlineData(1, "John", "", "Minsk", "johndoe@gmail.com", "Pass1234", false)]
        [InlineData(1, "John", null, "Minsk", "johndoe@gmail.com", "Pass1234", false)]
        [InlineData(1, "John", "Doe", "", "johndoe@gmail.com", "Pass1234", false)]
        [InlineData(1, "John", "Doe", null, "johndoe@gmail.com", "Pass1234", false)]
        [InlineData(1, "John", "Doe", "Minsk", "sometext", "Pass1234", false)]
        [InlineData(1, "John", "Doe", "Minsk", "", "Pass1234", false)]
        [InlineData(1, "John", "Doe", "Minsk", null, "Pass1234", false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", null, false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "", false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "Pass123", false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "pass1234", false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "Passpass", false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "12345678", false)]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", "PASS1234", false)]
        public void EmployeeRegisterDtoValidatorTests(
            int? organizationId,
            string firstName,
            string lastName,
            string hometown,
            string email,
            string password,
            bool isValid)
        {
            var employeeRegisterDto = new EmployeeRegisterDto()
            {
                OrganizationId = organizationId,
                FirstName = firstName,
                LastName = lastName,
                Hometown = hometown,
                Email = email,
                Password = password
            };

            Assert.Equal(isValid, _employeeRegisterDtoValidator.Validate(employeeRegisterDto).IsValid);
        }
    }
}
