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

namespace PracticumFinalCase.Persistence.Services
{
    public class UserService : BaseService<object, User>, IUserService
    {
        private readonly ITokenHandler tokenHandler;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IGenericRepository<User> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, ITokenHandler tokenHandler) : base(genericRepository, mapper, unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.tokenHandler = tokenHandler;
        }

        public async Task<BaseResponse<TokenDto>> LoginAsync(UserLoginDto dto)
        {
            User user = await unitOfWork.UserRepository.GetWhereFirstOrDefault(x => x.UserName == dto.Username);

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

        public override async Task<BaseResponse<object>> InsertAsync(object insertResource)
        {
            try
            {
                // Mapping Resource to Entity
                var tempEntity = mapper.Map<CreateUserDto, User>((CreateUserDto)insertResource);

                await unitOfWork.UserRepository.InsertAsync(tempEntity);
                await unitOfWork.CompleteAsync();

                Log.Information("New user created.");

                return new BaseResponse<object>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "CreateUser_Error");
                return new BaseResponse<object>("CreateUser_Error");
            }
        }

        public async Task<BaseResponse<object>> ResetPasswordAsync(ResetUserPasswordDto dto)
        {
            try
            {
                // Mapping Resource to Entity
                var tempEntity = mapper.Map<ResetUserPasswordDto, User>(dto);

                unitOfWork.UserRepository.UpdatePassword(tempEntity);
                await unitOfWork.CompleteAsync();

                Log.Information($"User with id: '{tempEntity.Id}' resetted password.");

                return new BaseResponse<object>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ResetUserPassword_Error");
                return new BaseResponse<object>("ResetUserPassword_Error");
            }
        }
    }
}
