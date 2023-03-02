using Microsoft.EntityFrameworkCore;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.Repositories
{
    public class ShoppingListRepository : GenericRepository<ShoppingList>, IShoppingListRepository
    {
        private readonly AppDbContext dbContext;

        public ShoppingListRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CompleteAsync(int id)
        {
            var entity = dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);

            entity.IsCompleted = true;

            entity.CompletionDate = DateTime.Now;

            dbContext.Update(entity);
        }

        public override async Task<IEnumerable<ShoppingList>> GetWhereAsync(Expression<Func<ShoppingList, bool>> method, bool isTracking = true)
        {
            var query = dbContext.ShoppingLists.Include(x => x.User).Include(x => x.Products).AsQueryable();

            if (!isTracking)
            {
                dbContext.ShoppingLists.AsNoTracking();
            }

            return query.Where(method);
        }

        public override async Task<ShoppingList> GetByIdAsync(int entityId)
        {
            var query = dbContext.ShoppingLists.Include(x => x.User).Include(x => x.Products).AsQueryable();

            return await query.FirstOrDefaultAsync(x => x.Id == entityId);
        }
    }
}
