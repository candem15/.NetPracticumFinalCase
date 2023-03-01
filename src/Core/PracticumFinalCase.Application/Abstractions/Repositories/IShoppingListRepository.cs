using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Abstractions.Repositories
{
    public interface IShoppingListRepository : IGenericRepository<ShoppingList>
    {
        void CompleteAsync(int id);
    }
}
