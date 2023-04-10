using FluentValidation;
using IdentityMS.Business.DTOs.Employee;

namespace IdentityMS.Business.Validators
{
    public class EmployeeRegisterDtoValidator : AbstractValidator<EmployeeRegisterDto>
    {
        public EmployeeRegisterDtoValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(e => e.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(e => e.Hometown)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(e => e.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[0-9]");
        }
    }
}
