using Microsoft.EntityFrameworkCore;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Domain.Types;
using PracticumFinalCase.Persistence.Contexts;
using PracticumFinalCase.Persistence.Extensions;
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

        public override async Task InsertAsync(User entity)
        {
            entity.Password = PasswordHasherExtension.HashPasword(entity.Password);
            entity.Role = Role.BasicUser;
            entity.LastActivity = DateTime.Now;
            await base.InsertAsync(entity);
        }
        public void UpdatePassword(User entity)
        {
            entity.Password = PasswordHasherExtension.HashPasword(entity.Password);
            base.Update(entity);
        }
    }
}
