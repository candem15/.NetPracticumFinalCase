using Microsoft.EntityFrameworkCore;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Persistence.Contexts;
using System.Linq.Expressions;

namespace PracticumFinalCase.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        protected readonly AppDbContext Context;
        private DbSet<Entity> entities;


        public GenericRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.entities = Context.Set<Entity>();
        }


        public virtual async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
        }

        public virtual async Task<IEnumerable<Entity>> GetWhereAsync(Expression<Func<Entity, bool>> method, bool isTracking = true)
        {
            var query = entities.AsQueryable();
            if (!isTracking)
                query = entities.AsNoTracking();
            return query.Where(method);
        }

        public virtual async Task InsertAsync(Entity entity)
        {
            var column = entity.GetType().GetProperty("CreatedAt");
            var column2 = entity.GetType().GetProperty("UpdatedAt");

            if(column is not null)
                entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.Now);

            if (column2 is not null)
                entity.GetType().GetProperty("UpdatedAt").SetValue(entity, DateTime.Now);

            await entities.AddAsync(entity);
        }

        public void Remove(Entity entity)
        {
            var column = entity.GetType().GetProperty("IsDeleted");
            if (column is not null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            }
            else
            {
                entities.Remove(entity);
            }
        }

        public virtual void Update(Entity entity)
        {
            var column = entity.GetType().GetProperty("UpdatedAt");
            if (column is not null)
            {
                entity.GetType().GetProperty("UpdatedAt").SetValue(entity, DateTime.Now);
            }
            entities.Update(entity);
        }
    }
}
