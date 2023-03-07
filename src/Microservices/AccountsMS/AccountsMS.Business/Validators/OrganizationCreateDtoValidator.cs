using AccountsMS.Business.DTOs.Organization;
using FluentValidation;

namespace AccountsMS.Business.Validators
{
    public class OrganizationCreateDtoValidator : AbstractValidator<OrganizationCreateDto>
    {
        public OrganizationCreateDtoValidator()
        {
            RuleFor(o => o.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(o => o.Hometown)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(o => o.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress();
        }
    }
}
