using AccountsMS.Business.DTOs.Employee;
using FluentValidation;

namespace AccountsMS.Business.Validators
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
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
        }
    }
}
