using AutoMapper;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Abstractions.Token;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.Services
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        private readonly ITokenHandler tokenHandler;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IGenericRepository<User> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, ITokenHandler tokenHandler) : base(genericRepository, mapper, unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.tokenHandler = tokenHandler;
        }

        public async Task<BaseResponse<TokenDto>> LoginAsync(UserLoginDto dto)
        {
            User user = (await unitOfWork.UserRepository.GetWhereAsync(x => x.UserName == dto.Username)).FirstOrDefault();

            if (user == null)
            {
                Log.Error("InvalidUserInformation");
                return new BaseResponse<TokenDto>("InvalidUserInformation");
            }

            var passwordVerified = PasswordHasherExtension.VerifyPassword(dto.Password, user.Password);

            if (!passwordVerified)
            {
                Log.Error("InvalidUserInformation");
                return new BaseResponse<TokenDto>("InvalidUserInformation");

            }

            user.LastActivity = DateTime.Now;
            unitOfWork.UserRepository.Update(user);
            await unitOfWork.CompleteAsync();

            TokenDto token = tokenHandler.CreateAccessToken(30, user);
            return new BaseResponse<TokenDto>(token);
        }
    }
}
