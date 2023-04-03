using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.Validators;

namespace AccountsMS.Tests.UnitTests.ValidationTests
{
    public class EmployeeValidationTests
    {
        private readonly EmployeeCreateDtoValidator _employeeCreateDtoValidator;
        private readonly EmployeeUpdateDtoValidator _employeeUpdateDtoValidator;

        public EmployeeValidationTests()
        {
            _employeeCreateDtoValidator = new EmployeeCreateDtoValidator();
            _employeeUpdateDtoValidator = new EmployeeUpdateDtoValidator();
        }

        [Theory]
        [InlineData(1, "John", "Doe", "Minsk", "johndoe@gmail.com", true)]
        [InlineData(1, "", "Doe", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, null, "Doe", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, "John", "", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, "John", null, "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, "John", "Doe", "", "johndoe@gmail.com", false)]
        [InlineData(1, "John", "Doe", null, "johndoe@gmail.com", false)]
        [InlineData(1, "John", "Doe", "Minsk", "sometext", false)]
        [InlineData(1, "John", "Doe", "Minsk", "", false)]
        [InlineData(1, "John", "Doe", "Minsk", null, false)]
        public void EmployeeCreateDtoValidatorTests(
            int? organizationId,
            string firstName,
            string lastName,
            string hometown,
            string email,
            bool isValid)
        {
            var employeeCreateDto = new EmployeeCreateDto()
            {
                OrganizationId = organizationId,
                FirstName = firstName,
                LastName = lastName,
                Hometown = hometown,
                Email = email
            };

            Assert.Equal(isValid, _employeeCreateDtoValidator.Validate(employeeCreateDto).IsValid);
        }

        [Theory]
        [InlineData(1, 1, "John", "Doe", "Minsk", "johndoe@gmail.com", true)]
        [InlineData(1, 1, "", "Doe", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, 1, null, "Doe", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, 1, "John", "", "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, 1, "John", null, "Minsk", "johndoe@gmail.com", false)]
        [InlineData(1, 1, "John", "Doe", "", "johndoe@gmail.com", false)]
        [InlineData(1, 1, "John", "Doe", null, "johndoe@gmail.com", false)]
        [InlineData(1, 1, "John", "Doe", "Minsk", "sometext", false)]
        [InlineData(1, 1, "John", "Doe", "Minsk", "", false)]
        [InlineData(1, 1, "John", "Doe", "Minsk", null, false)]
        public void EmployeeUpdateDtoValidatorTests(
            int id,
            int? organizationId,
            string firstName,
            string lastName,
            string hometown,
            string email,
            bool isValid)
        {
            var employeeUpdateDto = new EmployeeUpdateDto()
            {
                Id = id,
                OrganizationId = organizationId,
                FirstName = firstName,
                LastName = lastName,
                Hometown = hometown,
                Email = email
            };

            Assert.Equal(isValid, _employeeUpdateDtoValidator.Validate(employeeUpdateDto).IsValid);
        }
    }
}
