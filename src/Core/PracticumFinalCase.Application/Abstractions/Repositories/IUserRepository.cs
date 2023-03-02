using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Abstractions.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetWhereFirstOrDefault(Expression<Func<User, bool>> method, bool isTracking = true);
        void UpdatePassword(User entity);
    }
}
