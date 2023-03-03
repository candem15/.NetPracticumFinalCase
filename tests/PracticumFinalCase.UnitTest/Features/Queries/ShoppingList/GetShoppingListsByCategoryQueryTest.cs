using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCategory;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Queries.ShoppingList
{
    public class GetShoppingListsByCategoryQueryTest
    {
        private readonly Mock<IShoppingListService> shoppingListService;

        public GetShoppingListsByCategoryQueryTest()
        {
            shoppingListService = new Mock<IShoppingListService>();
        }

        [Fact]
        public async Task GetShoppingListsByCategoryQueryHandler_Should_Return_BaseResponse_Success_With_ShoppingListsResponse()
        {
            // Arrange
            var request = new GetShoppingListsByCategoryQueryRequest()
            {
                CategoryName = "Elektronik"
            };

            var responseBody = new List<ShoppingListDto>();

            shoppingListService.Setup(x => x.GetShoppingListsByCategory(It.IsAny<string>())).Returns(Task.FromResult(new BaseResponse<IEnumerable<ShoppingListDto>>(responseBody)));

            //Act & Assert
            var handler = new GetShoppingListsByCategoryQueryHandler(shoppingListService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Response.ShouldBeEquivalentTo(responseBody);
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new GetShoppingListsByCategoryQueryRequest()
            {
                CategoryName = "Elektronikxxx"
            };

            // Act&Assert
            GetShoppingListsByCategoryQueryRequestValidator validator = new ();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new GetShoppingListsByCategoryQueryRequest()
            {
                CategoryName = "Elektronik"
            };

            // Act&Assert
            GetShoppingListsByCategoryQueryRequestValidator validator = new ();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }
    }
}
