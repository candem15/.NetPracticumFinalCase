using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.ResetUserPassword
{
    public class ResetUserPasswordCommandRequestValidator : AbstractValidator<ResetUserPasswordCommandRequest>
    {
        public ResetUserPasswordCommandRequestValidator()
        {
            RuleFor(x => x.Dto.Id).NotEmpty()
                    .GreaterThanOrEqualTo(1).WithMessage("Invalid user id entered.");
            RuleFor(x => x.Dto.Password).NotEmpty().WithMessage("Your new password cannot be empty.")
                    .MinimumLength(8).WithMessage("Your new password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your new password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your new password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your new password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your new password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your new password must contain at least one (!? *.).");

        }
    }
}
