using MediatR;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.CompleteShoppingList
{
    public class CompleteShoppingListCommandRequest : IRequest<BaseResponse<object>>
    {
        public int Id { get; set; }
    }
}
