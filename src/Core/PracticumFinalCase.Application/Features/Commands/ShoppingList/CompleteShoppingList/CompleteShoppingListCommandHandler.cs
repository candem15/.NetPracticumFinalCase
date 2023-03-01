using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.CompleteShoppingList
{
    public class CompleteShoppingListCommandHandler : IRequestHandler<CompleteShoppingListCommandRequest, BaseResponse<object>>
    {
        private readonly IShoppingListService shoppingListService;

        public CompleteShoppingListCommandHandler(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        public async Task<BaseResponse<object>> Handle(CompleteShoppingListCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await shoppingListService.CompleteAsync(request.Id);

            return result;
        }
    }
}
