using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.CreateShoppingList
{
    public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommandRequest, BaseResponse<ShoppingListDto>>
    {
        private readonly IShoppingListService shoppingListService;

        public CreateShoppingListCommandHandler(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        public async Task<BaseResponse<ShoppingListDto>> Handle(CreateShoppingListCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await shoppingListService.InsertWithOnwerAsync(request.Dto , request.OwnerId);

            return result;
        }
    }
}
