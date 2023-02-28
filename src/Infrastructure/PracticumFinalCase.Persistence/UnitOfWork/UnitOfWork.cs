using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Contexts;
using PracticumFinalCase.Persistence.Repositories;
using Serilog;

namespace PracticumFinalCase.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        public IUserRepository UserRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IShoppingListRepository ShoppingListRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            UserRepository = new UserRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
            ShoppingListRepository = new ShoppingListRepository(dbContext);
        }

        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception occurred while committing db. Exception: {ex}");                          
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
