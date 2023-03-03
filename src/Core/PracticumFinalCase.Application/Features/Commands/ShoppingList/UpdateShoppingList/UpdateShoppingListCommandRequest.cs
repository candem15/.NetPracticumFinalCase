using MediatR;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.UpdateShoppingList
{
    public class UpdateShoppingListCommandRequest : IRequest<BaseResponse<object>>
    {
        public UpdateShoppingListDto Dto { get; set; }
    }
}
