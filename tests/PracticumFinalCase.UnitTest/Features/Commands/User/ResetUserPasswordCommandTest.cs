using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Features.Commands.User.ResetUserPassword;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.User
{
    public class ResetUserPasswordCommandTest
    {
        private readonly Mock<IUserService> userService;

        public ResetUserPasswordCommandTest()
        {
            userService = new Mock<IUserService>();
        }

        [Fact]
        public async Task ResetUserPasswordCommandHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new ResetUserPasswordCommandRequest()
            {
               Dto= new ResetUserPasswordDto()
               {
                   Id=1,
                   Password="testPassword"
               }
            };

            userService.Setup(x => x.ResetPasswordAsync(It.IsAny<ResetUserPasswordDto>())).Returns(Task.FromResult(new BaseResponse<object>(true)));

            //Act & Assert
            var handler = new ResetUserPasswordCommandHandler(userService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new ResetUserPasswordCommandRequest()
            {
                Dto = new ResetUserPasswordDto()
                {
                    Id = -1,
                    Password = "testPassword"
                }
            };

            // Act&Assert
            ResetUserPasswordCommandRequestValidator validator = new ResetUserPasswordCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new ResetUserPasswordCommandRequest()
            {
                Dto = new ResetUserPasswordDto()
                {
                    Id = 1,
                    Password = "123TestPass."
                }
            };

            // Act&Assert
            ResetUserPasswordCommandRequestValidator validator = new ResetUserPasswordCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
