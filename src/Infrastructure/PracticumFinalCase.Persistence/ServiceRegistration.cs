using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Contexts;
using PracticumFinalCase.Persistence.Extensions;
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

            services.AddSingleton(x => x.ConfigureRedis(redisHost: Configuration.RedisDbHost));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
            services.AddScoped<ICachedProductsRepository, CachedProductsRepository>();

            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IGenericRepository<ShoppingList>, GenericRepository<ShoppingList>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();

            // Automized migration.
            var optBuilder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(Configuration.ConnectionStringSqlServer);
            using var dbContext = new AppDbContext(optBuilder.Options);
            
            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();
        }
    }
}
