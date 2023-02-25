using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Response;

namespace PracticumFinalCase.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, BaseResponse<TokenDto>>
    {
        private readonly IUserService userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<BaseResponse<TokenDto>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await userService.LoginAsync(request.Dto);

            return response;
        }
    }
}
