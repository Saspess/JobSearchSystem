using FluentValidation;
using IdentityMS.Business.DTOs.Organization;

namespace IdentityMS.Business.Validators
{
    public class OrganizationRegisterDtoValidator : AbstractValidator<OrganizationRegisterDto>
    {
        public OrganizationRegisterDtoValidator()
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

            RuleFor(o => o.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[0-9]");

            RuleFor(o => o.Role)
                .NotNull()
                .NotEmpty()
                .IsInEnum();
        }
    }
}
