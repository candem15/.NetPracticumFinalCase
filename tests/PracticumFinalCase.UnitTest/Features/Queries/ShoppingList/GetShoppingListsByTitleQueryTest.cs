using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByTitle;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Queries.ShoppingList
{
    public class GetShoppingListsByTitleQueryTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public GetShoppingListsByTitleQueryTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task GetShoppingListsByTitleQueryHandler_Should_Return_BaseResponse_Success_With_ShoppingListsResponse()
        {
            // Arrange
            var request = new GetShoppingListsByTitleQueryRequest()
            {
                Title = "test"
            };

            var responseBody = new List<ShoppingListDto>();

            shoppingListService.Setup(x => x.GetShoppingListsByTitle(It.IsAny<string>())).Returns(Task.FromResult(new BaseResponse<IEnumerable<ShoppingListDto>>(responseBody)));

            //Act & Assert
            var handler = new GetShoppingListsByTitleQueryHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Response.ShouldBeEquivalentTo(responseBody);
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new GetShoppingListsByTitleQueryRequest()
            {
                Title=""
            };

            // Act&Assert
            GetShoppingListsByTitleQueryRequestValidator validator = new GetShoppingListsByTitleQueryRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new GetShoppingListsByTitleQueryRequest()
            {
                Title = "Valid Title"
            };

            // Act&Assert
            GetShoppingListsByTitleQueryRequestValidator validator = new GetShoppingListsByTitleQueryRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
