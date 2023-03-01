using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandRequestValidator : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandRequestValidator()
        {
            RuleFor(x => x.Dto.Username).NotEmpty();
            RuleFor(x => x.Dto.Password).NotEmpty().WithMessage("Your password cannot be empty");
        }
    }
}
