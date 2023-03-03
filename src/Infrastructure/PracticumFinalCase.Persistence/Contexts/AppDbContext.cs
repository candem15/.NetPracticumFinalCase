using Microsoft.EntityFrameworkCore;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Migration işlemi gereğinden uzun sürdüğü için hata alınırsa aşağıdaki satırı aktif ediniz.
            //this.Database.SetCommandTimeout(999999);
        }

        // dbsets
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Entity configurations applied.
            builder.ApplyConfiguration(new ShoppingListEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
