using FluentValidation;
using IdentityMS.Business.DTOs.User;

namespace IdentityMS.Business.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[0-9]");

            RuleFor(u => u.Role)
                .NotNull()
                .NotEmpty()
                .IsInEnum();
        }
    }
}
