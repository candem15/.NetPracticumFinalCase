using MediatR;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest : IRequest<BaseResponse<Object>>
    {
        public CreateUserDto Dto { get; set; }
    }
}
