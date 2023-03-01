using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.Domain.Models;

namespace PracticumFinalCase.Application.Abstractions.Services
{
    public interface IUserService : IBaseService<object, User>
    {
        Task<BaseResponse<TokenDto>> LoginAsync(UserLoginDto dto);
        Task<BaseResponse<object>> ResetPasswordAsync(ResetUserPasswordDto dto);
    }
}
