using IdentityMS.Business.DTOs.Enums;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Business.Validators;

namespace IdentityMS.Tests.UnitTests.ValidationTests
{
    public class UserValidationTests
    {
        private readonly UserLoginDtoValidator _userLoginDtoValidator;
        private readonly UserRegisterDtoValidator _userRegisterDtoValidator;
        private readonly UserUpdateDtoValidator _userUpdateDtoValidator;

        public UserValidationTests()
        {
            _userLoginDtoValidator = new UserLoginDtoValidator();
            _userRegisterDtoValidator = new UserRegisterDtoValidator();
            _userUpdateDtoValidator = new UserUpdateDtoValidator();
        }

        [Theory]
        [InlineData("", "Pass1234", false)]
        [InlineData(null, "Pass1234", false)]
        [InlineData("sometext", "Pass1234", false)]
        [InlineData("johndoe@gmail.com", null, false)]
        [InlineData("johndoe@gmail.com", "", false)]
        [InlineData("johndoe@gmail.com", "Pass123", false)]
        [InlineData("johndoe@gmail.com", "pass1234", false)]
        [InlineData("johndoe@gmail.com", "Passpass", false)]
        [InlineData("johndoe@gmail.com", "PASS1234", false)]
        public void UserLoginDtoValidatorTests(
            string email,
            string password,
            bool isValid)
        {
            var userLoginDto = new UserLoginDto()
            {
                Email = email,
                Password = password
            };

            Assert.Equal(isValid, _userLoginDtoValidator.Validate(userLoginDto).IsValid);
        }

        [Theory]
        [InlineData("johndoe@gmail.com", "Pass1234", 1, true)]
        [InlineData("", "Pass1234", 1, false)]
        [InlineData(null, "Pass1234", 1, false)]
        [InlineData("sometext", "Pass1234", 1, false)]
        [InlineData("johndoe@gmail.com", null, 1, false)]
        [InlineData("johndoe@gmail.com", "", 1, false)]
        [InlineData("johndoe@gmail.com", "Pass123", 1, false)]
        [InlineData("johndoe@gmail.com", "pass1234", 1, false)]
        [InlineData("johndoe@gmail.com", "Passpass", 1, false)]
        [InlineData("johndoe@gmail.com", "PASS1234", 1, false)]
        [InlineData("johndoe@gmail.com", "Pass1234", -1, false)]
        [InlineData("johndoe@gmail.com", "Pass1234", 5, false)]

        public void UserRegisterDtoValidatorTests(
            string email,
            string password,
            int role,
            bool isValid)
        {
            var userRegisterDto = new UserRegisterDto()
            {
                Email = email,
                Password = password,
                Role = (Roles)role
            };

            Assert.Equal(isValid, _userRegisterDtoValidator.Validate(userRegisterDto).IsValid);
        }

        [Theory]
        [InlineData(1, "johndoe@gmail.com", "Pass1234", 1, true)]
        [InlineData(1, "", "Pass1234", 1, false)]
        [InlineData(1, null, "Pass1234", 1, false)]
        [InlineData(1, "sometext", "Pass1234", 1, false)]
        [InlineData(1, "johndoe@gmail.com", null, 1, false)]
        [InlineData(1, "johndoe@gmail.com", "", 1, false)]
        [InlineData(1, "johndoe@gmail.com", "Pass123", 1, false)]
        [InlineData(1, "johndoe@gmail.com", "pass1234", 1, false)]
        [InlineData(1, "johndoe@gmail.com", "Passpass", 1, false)]
        [InlineData(1, "johndoe@gmail.com", "PASS1234", 1, false)]
        [InlineData(1, "johndoe@gmail.com", "Pass1234", -1, false)]
        [InlineData(1, "johndoe@gmail.com", "Pass1234", 5, false)]

        public void UserUpdateDtoValidatorTests(
            int id,
            string email,
            string password,
            int role,
            bool isValid)
        {
            var userUpdateDto = new UserUpdateDto()
            {
                Id = id,
                Email = email,
                Password = password,
                Role = (Roles)role
            };

            Assert.Equal(isValid, _userUpdateDtoValidator.Validate(userUpdateDto).IsValid);
        }
    }
}
