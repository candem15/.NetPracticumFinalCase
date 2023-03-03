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
    public interface IShoppingListService : IBaseService<Object, ShoppingList>
    {
        Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetShoppingListsByTitle(string title);
        Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetShoppingListsByCategory(string categoryName);
        Task<BaseResponse<ShoppingListDto>> InsertWithOwnerAsync(CreateShoppingListDto insertResource, int ownerId);
        Task<BaseResponse<object>> CompleteAsync(int id);
        Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetByCreateDateAsync(string createDate);

    }
}
