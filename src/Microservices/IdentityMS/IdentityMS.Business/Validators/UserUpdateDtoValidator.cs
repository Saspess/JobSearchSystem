using FluentValidation;
using IdentityMS.Business.DTOs.User;

namespace IdentityMS.Business.Validators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(e => e.Id)
                .NotNull();

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

            RuleFor(e => e.Role)
                .NotNull()
                .NotEmpty()
                .IsInEnum();
        }
    }
}
