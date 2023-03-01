using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.User.ResetUserPassword
{
    public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommandRequest, BaseResponse<object>>
    {
        private readonly IUserService userService;

        public ResetUserPasswordCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<BaseResponse<object>> Handle(ResetUserPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await userService.ResetPasswordAsync(request.Dto);

            return result;
        }
    }
}
