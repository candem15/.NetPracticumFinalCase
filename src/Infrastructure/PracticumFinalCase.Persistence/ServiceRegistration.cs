using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Contexts;
using PracticumFinalCase.Persistence.Repositories;
using PracticumFinalCase.Persistence.Services;

namespace PracticumFinalCase.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.ConnectionStringSqlServer);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUserService, UserService>();

            var optBuilder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(Configuration.ConnectionStringSqlServer);

            using var dbContext = new AppDbContext(optBuilder.Options);

            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }
    }
}
