using MediatR;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByTitle
{
    public class GetShoppingListsByTitleQueryRequest : IRequest<BaseResponse<IEnumerable<ShoppingListDto>>>
    {
        public string Title { get; set; }
    }
}
