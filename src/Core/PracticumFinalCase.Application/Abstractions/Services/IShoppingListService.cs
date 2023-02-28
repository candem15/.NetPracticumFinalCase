using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Abstractions.Services
{
    public interface IShoppingListService : IBaseService<ShoppingListDto, ShoppingList>
    {
        Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetShoppingListsByTitle(string title);
    }
}
