using BusinessAccessLayer.DTOs;
using FluentValidation;

namespace BusinessAccessLayer.Validators
{
    public class UserDTOValidator: AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(user => user.UserLogin)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .EmailAddress().WithMessage("Invalid email format!");

            RuleFor(user => user.UserPassword)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .Matches("^[a-zA-Zа-яА-Я]+$").WithMessage("First Name field should contain only letters.");

            RuleFor(user => user.UserSurname)
                .NotEmpty().WithMessage(ValidatorConst.emptyErrorMessage)
                .Matches("^[a-zA-Zа-яА-Я]+$").WithMessage("Surname field should contain only letters.");

        }
    }
}
