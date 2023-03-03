using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.CreateShoppingList;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.ShoppingList
{
    public class CreateShoppingListCommandTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public CreateShoppingListCommandTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task CreateShoppingListCommandHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new CreateShoppingListCommandRequest()
            {
                OwnerId = 1,
                Dto = new CreateShoppingListDto()
                {
                    CategoryName = "Electronic",
                    Title = "Powerfull pc units."
                }
            };

            shoppingListService.Setup(x => x.InsertWithOwnerAsync(It.IsAny<CreateShoppingListDto>(),It.IsAny<int>())).Returns(Task.FromResult(new BaseResponse<ShoppingListDto>(true)));

            //Act & Assert
            var handler = new CreateShoppingListCommandHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new CreateShoppingListCommandRequest()
            {
                OwnerId = -5,
                Dto = new CreateShoppingListDto()
                {
                    CategoryName = "invlaid",
                    Title = ""
                }
            };

            // Act&Assert
            CreateShoppingListCommandRequestValidator validator = new CreateShoppingListCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new CreateShoppingListCommandRequest()
            {
                OwnerId = 1,
                Dto = new CreateShoppingListDto()
                {
                    CategoryName = "Elektronik",
                    Title = "Pc setup items"
                }
            };

            // Act&Assert
            CreateShoppingListCommandRequestValidator validator = new CreateShoppingListCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
