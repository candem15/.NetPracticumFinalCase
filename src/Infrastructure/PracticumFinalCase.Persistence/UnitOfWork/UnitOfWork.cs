using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Contexts;
using PracticumFinalCase.Persistence.Repositories;

namespace PracticumFinalCase.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        public IGenericRepository<User> UserRepository { get; private set; }
        //public IGenericRepository<Person> PersonRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            UserRepository = new GenericRepository<User>(dbContext);
            //PersonRepository = new GenericRepository<Person>(dbContext);
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
                    // logging                    
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
