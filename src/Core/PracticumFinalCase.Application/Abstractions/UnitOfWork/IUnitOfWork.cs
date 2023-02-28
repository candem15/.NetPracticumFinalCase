using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Domain.Models;

namespace PracticumFinalCase.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IShoppingListRepository ShoppingListRepository { get; }
        Task CompleteAsync();
    }
}
