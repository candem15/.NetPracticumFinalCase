using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingLists;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Queries.ShoppingList
{
    public class GetShoppingListsQueryTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public GetShoppingListsQueryTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task GetShoppingListsByTitleQueryHandler_Should_Return_BaseResponse_Success_With_ShoppingListsResponse()
        {
            // Arrange
            var request = new GetShoppingListsQueryRequest();
            
            var responseBody = new List<ShoppingListDto>();

            shoppingListService.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(new BaseResponse<IEnumerable<object>>(responseBody)));

            //Act & Assert
            var handler = new GetShoppingListsQueryHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Response.ShouldBeEquivalentTo(responseBody);
        }
    }
}
