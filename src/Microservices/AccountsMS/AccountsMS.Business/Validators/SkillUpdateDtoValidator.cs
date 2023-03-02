using AccountsMS.Business.DTOs.Skill;
using FluentValidation;

namespace AccountsMS.Business.Validators
{
    public class SkillUpdateDtoValidator : AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateDtoValidator()
        {
            RuleFor(s => s.Id)
                .NotNull();

            RuleFor(s => s.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
