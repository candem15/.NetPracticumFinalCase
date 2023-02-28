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

                        logger.LogInformation("Predefined users seeded to db.");
                    }

                    if (!context.Products.Any())
                    {
                        context.Products.AddRange(GetPredefinedProducts());

                        await context.SaveChangesAsync();

                        logger.LogInformation("Predefined products seeded to db.");
                    }

                    if (!context.ShoppingLists.Any())
                    {
                        context.ShoppingLists.AddRange(GetPredefinedShoppingLists(context));

                        await context.SaveChangesAsync();

                        logger.LogInformation("Predefined shopping lists seeded to db.");
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
                    PhoneNumber= "5543812170",
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
                    PhoneNumber= "5543812170",
                    Role= Role.Admin
                },
            };
        }

        private IEnumerable<Product> GetPredefinedProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Bread",
                    Description="Cripy outside and soft inside loaf.",
                    Quantity=1,
                    Measurement=Measurement.Unit,
                    Price= 5,
                    UpdatedAt= DateTime.Now

                },
                new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Milk",
                    Description="The liquid produced by the mammary glands of mammals, including humans. This product produced from dairy cow.",
                    Quantity=1,
                    Measurement=Measurement.Liter,
                    Price= 20,
                    UpdatedAt= DateTime.Now
                },
                new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Sugar",
                    Description="The generic name for sweet-tasting, soluble carbohydrates, many of which are used in food.",
                    Quantity=1,
                    Measurement=Measurement.Kilogram,
                    Price= 30,
                    UpdatedAt= DateTime.Now
                },
                new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Salt",
                    Description="A mineral composed primarily of sodium chloride (NaCl). Most common usage of this product is giving salty flavour to foods.",
                    Quantity=1,
                    Measurement=Measurement.Kilogram,
                    Price= 6.6m,
                    UpdatedAt= DateTime.Now
                },
                new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Book",
                    Description="A written or printed work consisting of pages glued or sewn together along one side and bound in covers.",
                    Quantity=1,
                    Measurement=Measurement.Unit,
                    Price= 15,
                    UpdatedAt= DateTime.Now
                },
                new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Pencil",
                    Description="An instrument for writing or drawing.",
                    Quantity=1,
                    Measurement=Measurement.Unit,
                    Price= 3,
                    UpdatedAt= DateTime.Now
                },new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Mobile Phone",
                    Description="Portable device for connecting to a telecommunications network in order to transmit and receive voice, video, or other data.",
                    Quantity=1,
                    Measurement=Measurement.Unit,
                    Price= 2500,
                    UpdatedAt= DateTime.Now
                },new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Calculator",
                    Description="A device that performs arithmetic operations on numbers.",
                    Quantity=1,
                    Measurement=Measurement.Unit,
                    Price= 50,
                    UpdatedAt= DateTime.Now
                },new Product()
                {
                    CreatedAt = DateTime.Now,
                    Name= "Keyboard",
                    Description="One of the primary input devices used with a computer. Similar to an electric typewriter, a keyboard is composed of buttons used to create letters, numbers, and symbols, and perform additional functions.",
                    Quantity=1,
                    Measurement=Measurement.Unit,
                    Price= 350,
                    UpdatedAt= DateTime.Now
                },

            };
        }

        private IEnumerable<ShoppingList> GetPredefinedShoppingLists(AppDbContext context)
        {
            return new List<ShoppingList>()
            {
                new ShoppingList()
                {
                    CategoryName = Category.Grocery,
                    OwnerId = 4,
                    Title = "Daily supplies",
                    Products= context.Products.Where(x=>x.Name=="Milk"||x.Name=="Bread"||x.Name=="Sugar").ToList(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt= DateTime.Now
                 },
                new ShoppingList()
                {
                    CategoryName = Category.StationeryOffice,
                    OwnerId = 4,
                    Title = "Painting course shopping",
                    Products= context.Products.Where(x=>x.Name=="Book"||x.Name=="Pencil").ToList(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt= DateTime.Now
                 }
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
