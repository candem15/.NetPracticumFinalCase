using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<object>>
    {
        private readonly IUserService userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<BaseResponse<object>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await userService.InsertAsync(request.Dto);

            return result;
        }
    }
}
