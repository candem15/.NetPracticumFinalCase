using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.UpdateShoppingList
{
    public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommandRequest, BaseResponse<Object>>
    {
        private readonly IShoppingListService shoppingListService;

        public UpdateShoppingListCommandHandler(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        public async Task<BaseResponse<Object>> Handle(UpdateShoppingListCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await shoppingListService.UpdateAsync(request.Dto.Id, request.Dto);

            return result;
        }
    }
}
