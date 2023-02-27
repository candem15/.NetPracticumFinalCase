using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Domain.Types;
using PracticumFinalCase.Persistence.Extensions;

namespace PracticumFinalCase.Persistence.Contexts
{
    public class AppDbContextSeed
    {
        public async Task SeedAsync(AppDbContext context, ILogger<AppDbContext> logger)
        {
            var policy = CreatePolicy(logger);

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(GetPredefinedUsers());

                        await context.SaveChangesAsync();
                    }
                }
            });
        }

        private IEnumerable<User> GetPredefinedUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    UserName = "johnsmith",
                    Password = PasswordHasherExtension.HashPasword("123smith."),
                    Email= "johnsmith@email.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastActivity=DateTime.Now,
                    Name="John Smith",
                    PhoneNumber= "905543812170",
                    Role= Role.BasicUser
                },
                new User()
                {
                    UserName = "admin",
                    Password = PasswordHasherExtension.HashPasword("123admin."),
                    Email= "eraybrbr@email.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastActivity=DateTime.Now,
                    Name="Eray Berberoğlu",
                    PhoneNumber= "905543812170",
                    Role= Role.Admin
                },
            };
        }

        private AsyncRetryPolicy CreatePolicy(ILogger<AppDbContext> logger, int retries = 3)
        {
            return Policy.Handle<SqlException>()
                            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), retries),
                                onRetry: (exception, timeSpan, retry, ctx) =>
                                {
                                    logger.LogWarning(exception, "Exeception Type: {exception} occurred!");
                                });
        }
    }
}
