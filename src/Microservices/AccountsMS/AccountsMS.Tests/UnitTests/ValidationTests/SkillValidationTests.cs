using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Validators;

namespace AccountsMS.Tests.UnitTests.ValidationTests
{
    public class SkillValidationTests
    {
        private readonly SkillCreateDtoValidator _skillCreateDtoValidator;
        private readonly SkillUpdateDtoValidator _skillUpdateDtoValidator;

        public SkillValidationTests()
        {
            _skillCreateDtoValidator = new SkillCreateDtoValidator();
            _skillUpdateDtoValidator = new SkillUpdateDtoValidator();
        }

        [Theory]
        [InlineData("Git", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void SkillCreateDtoValidatorTests(
            string name,
            bool isValid)
        {
            var skillCreateDto = new SkillCreateDto()
            {
                Name = name
            };

            Assert.Equal(isValid, _skillCreateDtoValidator.Validate(skillCreateDto).IsValid);
        }

        [Theory]
        [InlineData(1, "Git", true)]
        [InlineData(1, "", false)]
        [InlineData(1, null, false)]
        public void SkillUpdateDtoValidatorTests(
            int id,
            string name,
            bool isValid)
        {
            var skillUpdateDto = new SkillUpdateDto()
            {
                Id = id,
                Name = name
            };

            Assert.Equal(isValid, _skillUpdateDtoValidator.Validate(skillUpdateDto).IsValid);
        }
    }
}
