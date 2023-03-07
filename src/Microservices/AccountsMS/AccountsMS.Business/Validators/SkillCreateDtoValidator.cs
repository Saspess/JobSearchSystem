using AccountsMS.Business.DTOs.Skill;
using FluentValidation;

namespace AccountsMS.Business.Validators
{
    public class SkillCreateDtoValidator : AbstractValidator<SkillCreateDto>
    {
        public SkillCreateDtoValidator()
        {
            RuleFor(s => s.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
