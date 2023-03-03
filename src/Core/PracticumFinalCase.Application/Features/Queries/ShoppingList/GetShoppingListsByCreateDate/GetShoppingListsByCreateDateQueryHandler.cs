using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCreateDate
{
    public class GetShoppingListsByCreateDateQueryHandler : IRequestHandler<GetShoppingListsByCreateDateQueryRequest, BaseResponse<IEnumerable<ShoppingListDto>>>
    {
        private readonly IShoppingListService service;

        public GetShoppingListsByCreateDateQueryHandler(IShoppingListService service)
        {
            this.service = service;
        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> Handle(GetShoppingListsByCreateDateQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetByCreateDateAsync(request.Date);

            return result;
        }
    }
}
