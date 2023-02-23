using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Application.Repositories;
using PracticumFinalCase.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        //public IGenericRepository<Account> AccountRepository { get; private set; }
        //public IGenericRepository<Person> PersonRepository { get; private set; }


        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            //AccountRepository = new GenericRepository<Account>(dbContext);
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
