using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByTitle
{
    public class GetShoppingListsByTitleQueryHandler : IRequestHandler<GetShoppingListsByTitleQueryRequest, BaseResponse<IEnumerable<ShoppingListDto>>>
    {
        private readonly IShoppingListService shoppingListService;

        public GetShoppingListsByTitleQueryHandler(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> Handle(GetShoppingListsByTitleQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await shoppingListService.GetShoppingListsByTitle(request.Title);

            return result;
        }
    }
}
