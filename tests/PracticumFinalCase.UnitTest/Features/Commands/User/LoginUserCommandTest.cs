using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Features.Commands.User.LoginUser;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.User
{
    public class LoginUserCommandTest
    {
        private readonly Mock<IUserService> userService;

        public LoginUserCommandTest()
        {
            userService = new Mock<IUserService>();
        }

        [Fact]
        public async Task LoginUserCommanddHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new LoginUserCommandRequest()
            {
                Dto = new UserLoginDto()
                {
                    Username = "test",
                    Password = "test"
                }
            };

            userService.Setup(x => x.LoginAsync(It.IsAny<UserLoginDto>())).Returns(Task.FromResult(new BaseResponse<TokenDto>(true)));

            //Act & Assert
            var handler = new LoginUserCommandHandler(userService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new LoginUserCommandRequest()
            {
                Dto = new UserLoginDto()
                {
                    Username = "",
                    Password = ""
                }
            };

            // Act&Assert
            LoginUserCommandRequestValidator validator = new LoginUserCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new LoginUserCommandRequest()
            {
                Dto = new UserLoginDto()
                {
                    Username = "test",
                    Password = "test"
                }
            };

            // Act&Assert
            LoginUserCommandRequestValidator validator = new LoginUserCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
