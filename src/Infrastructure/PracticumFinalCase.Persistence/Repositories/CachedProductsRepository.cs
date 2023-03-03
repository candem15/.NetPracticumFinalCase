using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Domain.Models;
using PracticumFinalCase.Persistence.Contexts;
using System.Text;

namespace PracticumFinalCase.Persistence.Repositories
{
    public class CachedProductsRepository : ICachedProductsRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IDistributedCache distributedCache;

        public CachedProductsRepository(AppDbContext dbContext, IDistributedCache distributedCache)
        {
            this.dbContext = dbContext;
            this.distributedCache = distributedCache;
        }

        public async Task<IEnumerable<Product>> GetCachedProducts()
        {
            string cacheKey = "CachedProducts";
            IEnumerable<Product> products;
            string json;

            var productsFromCache = await distributedCache.GetAsync(cacheKey);
            if (productsFromCache != null)
            {
                json = Encoding.UTF8.GetString(productsFromCache);
                products = JsonConvert.DeserializeObject<List<Product>>(json);
                return products;
            }
            else
            {
                var tempList = dbContext.Products.ToList();

                json = JsonConvert.SerializeObject(tempList);
                productsFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1)) // belirli bir süre erişilmemiş ise expire eder
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.
                await distributedCache.SetAsync(cacheKey, productsFromCache, options);

                return tempList;
            }
        }
    }
}
