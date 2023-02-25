using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PracticumFinalCase.Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly IConfiguration configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
