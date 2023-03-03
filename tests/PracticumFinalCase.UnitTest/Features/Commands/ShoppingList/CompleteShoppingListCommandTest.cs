using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.CompleteShoppingList;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.ShoppingList
{
    public class CompleteShoppingListCommandTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public CompleteShoppingListCommandTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task CompleteShoppingListCommandHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new CompleteShoppingListCommandRequest()
            {
                Id = 1
            };

            shoppingListService.Setup(x => x.CompleteAsync( It.IsAny<int>())).Returns(Task.FromResult(new BaseResponse<object>(true)));

            //Act & Assert
            var handler = new CompleteShoppingListCommandHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }
    }
}
