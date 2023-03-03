using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCreateDate;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Queries.ShoppingList
{
    public class GetShoppingListsByCreateDateQueryTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public GetShoppingListsByCreateDateQueryTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task GetShoppingListsByTitleQueryHandler_Should_Return_BaseResponse_Success_With_ShoppingListsResponse()
        {
            // Arrange
            var request = new GetShoppingListsByCreateDateQueryRequest()
            {
                Date = "2012-01-26T13:51:50.417-07:00"
            };

            var responseBody = new List<ShoppingListDto>();

            shoppingListService.Setup(x => x.GetByCreateDateAsync(It.IsAny<string>())).Returns(Task.FromResult(new BaseResponse<IEnumerable<ShoppingListDto>>(responseBody)));

            //Act & Assert
            var handler = new GetShoppingListsByCreateDateQueryHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Response.ShouldBeEquivalentTo(responseBody);
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new GetShoppingListsByCreateDateQueryRequest()
            {
                Date = "681423861-dedead-0-123"
            };

            // Act&Assert
            GetShoppingListsByCreateDateQueryRequestValidator validator = new GetShoppingListsByCreateDateQueryRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new GetShoppingListsByCreateDateQueryRequest()
            {
                Date = "2012-01-26T13:51:50.417-07:00"
            };

            // Act&Assert
            GetShoppingListsByCreateDateQueryRequestValidator validator = new();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
