using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCategory
{
    public class GetShoppingListsByCategoryQueryHandler : IRequestHandler<GetShoppingListsByCategoryQueryRequest, BaseResponse<IEnumerable<ShoppingListDto>>>
    {
        private readonly IShoppingListService service;

        public GetShoppingListsByCategoryQueryHandler(IShoppingListService service)
        {
            this.service = service;
        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> Handle(GetShoppingListsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetShoppingListsByCategory(request.CategoryName);

            return result;
        }
    }
}
