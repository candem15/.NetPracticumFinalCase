using MediatR;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCategory
{
    public class GetShoppingListsByCategoryQueryRequest : IRequest<BaseResponse<IEnumerable<ShoppingListDto>>>
    {
        public string CategoryName { get; set; }
    }
}
