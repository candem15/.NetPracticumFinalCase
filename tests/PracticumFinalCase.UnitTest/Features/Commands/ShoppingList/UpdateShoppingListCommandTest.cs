using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.UpdateShoppingList;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.ShoppingList
{
    public class UpdateShoppingListCommandTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public UpdateShoppingListCommandTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task UpdateShoppingListCommandHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new UpdateShoppingListCommandRequest()
            {
                Dto = new UpdateShoppingListDto()
                {
                    Id = 1,
                    CategoryName = "Elektronik",
                    ProductsId = new List<string>() { "1", "2" },
                    Title = "Same title"
                }
            };

            shoppingListService.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<object>())).Returns(Task.FromResult(new BaseResponse<object>(true)));

            //Act & Assert
            var handler = new UpdateShoppingListCommandHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new UpdateShoppingListCommandRequest()
            {
                Dto = new UpdateShoppingListDto()
                {
                    CategoryName = "invlaid",
                    Title = "",
                    Id = 1,
                    ProductsId = new List<string>() { "a", "b" }
                }
            };

            // Act&Assert
            UpdateShoppingListCommandRequestValidator validator = new UpdateShoppingListCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new UpdateShoppingListCommandRequest()
            {
                Dto = new UpdateShoppingListDto()
                {
                    CategoryName = "Elektronik",
                    Title = "same title",
                    Id = 1,
                    ProductsId = new List<string>() { "1", "2" }
                }
            };

            // Act&Assert
            UpdateShoppingListCommandRequestValidator validator = new UpdateShoppingListCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
