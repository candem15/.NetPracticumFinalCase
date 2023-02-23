using PracticumFinalCase.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<Account> AccountRepository { get; }
        //IGenericRepository<Person> PersonRepository { get; }

        Task CompleteAsync();
    }
}
