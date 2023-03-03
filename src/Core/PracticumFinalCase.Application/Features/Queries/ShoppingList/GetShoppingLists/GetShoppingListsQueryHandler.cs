using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingLists
{
    public class GetShoppingListsQueryHandler : IRequestHandler<GetShoppingListsQueryRequest, BaseResponse<IEnumerable<object>>>
    {
        private readonly IShoppingListService shoppingListService;

        public GetShoppingListsQueryHandler(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        public async Task<BaseResponse<IEnumerable<object>>> Handle(GetShoppingListsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await shoppingListService.GetAllAsync();

            return result;
        }
    }
}
