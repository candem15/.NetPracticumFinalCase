using MediatR;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.CreateShoppingList
{
    public class CreateShoppingListCommandRequest: IRequest<BaseResponse<ShoppingListDto>>
    {
        public int OwnerId { get; set; }
        public CreateShoppingListDto Dto { get; set; }
    }
}
