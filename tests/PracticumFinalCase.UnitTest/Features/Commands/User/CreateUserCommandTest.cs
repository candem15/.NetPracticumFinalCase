using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Application.Features.Commands.User.CreateUser;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.User
{
    public class CreateUserCommandTest
    {
        private readonly Mock<IUserService> userService;

        public CreateUserCommandTest()
        {
            userService = new Mock<IUserService>();
        }

        [Fact]
        public async Task CreateUserCommanddHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new CreateUserCommandRequest()
            {
                Dto = new CreateUserDto()
                {
                    Email="eray@gmail.com",
                    Name="Eray Berberoğlu",
                    Password="123eray.",
                    PhoneNumber="5543812170",
                    UserName="erayUser"
                }
            };

            userService.Setup(x => x.InsertAsync(It.IsAny<object>())).Returns(Task.FromResult(new BaseResponse<object>(true)));

            //Act & Assert
            var handler = new CreateUserCommandHandler(userService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new CreateUserCommandRequest()
            {
                Dto = new CreateUserDto()
                {
                    Email = "e.com",
                    Name = "",
                    Password = "123123123",
                    PhoneNumber = "5543813453452170",
                    UserName = "."
                }
            };

            // Act&Assert
            CreateUserCommandRequestValidator validator = new CreateUserCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new CreateUserCommandRequest()
            {
                Dto = new CreateUserDto()
                {
                    Email = "eray@gmail.com",
                    Name = "Eray Berberoglu",
                    Password = "123Eraybrbr.",
                    PhoneNumber = "5543812170",
                    UserName = "erayUser"
                }
            };

            // Act&Assert
            CreateUserCommandRequestValidator validator = new CreateUserCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
