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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetWhereFirstOrDefault(Expression<Func<User, bool>> method, bool isTracking = true)
        {
           
            var query = dbContext.Users.AsQueryable();
            if (!isTracking)
                query = dbContext.Users.AsNoTracking();
            return query.Where(method).FirstOrDefault();
        }
    }
}
