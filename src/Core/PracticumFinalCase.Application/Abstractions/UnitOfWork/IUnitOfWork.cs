using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Domain.Models;

namespace PracticumFinalCase.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        //IGenericRepository<Person> PersonRepository { get; }

        Task CompleteAsync();
    }
}
