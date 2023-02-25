using MediatR;
using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandRequest : IRequest<BaseResponse<TokenDto>>
    {
        public UserLoginDto Dto { get; }
    }
}
