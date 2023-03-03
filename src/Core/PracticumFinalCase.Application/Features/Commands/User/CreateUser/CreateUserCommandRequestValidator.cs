using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandRequestValidator()
        {
            RuleFor(x => x.Dto.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Dto.UserName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Dto.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Dto.PhoneNumber).NotEmpty()
                    .Must(x => x.Length == 10).WithMessage("Your phone number must be 10 digits.")
                    .Must(x => long.TryParse(x, out long val) && val >= 0).WithMessage("Invalid phone number.");
            RuleFor(x => x.Dto.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

        }
    }
}
