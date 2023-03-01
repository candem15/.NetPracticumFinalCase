using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.DeleteShoppingList
{
    public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommandRequest, BaseResponse<Object>>
    {
        private readonly IShoppingListService shoppingListService;

        public DeleteShoppingListCommandHandler(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        public async Task<BaseResponse<object>> Handle(DeleteShoppingListCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await shoppingListService.RemoveAsync(request.Id);

            return result;
        }
    }
}
