using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Domain.Models;

namespace PracticumFinalCase.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minutes, User user);
        string CreateRefreshToken();
    }
}
