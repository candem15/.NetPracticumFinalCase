using MediatR;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingLists
{
    public class GetShoppingListsQueryRequest : IRequest<BaseResponse<IEnumerable<object>>>
    {
    }
}
