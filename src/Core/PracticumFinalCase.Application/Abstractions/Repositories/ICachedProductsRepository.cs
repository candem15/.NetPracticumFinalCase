using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Abstractions.Repositories
{
    public interface ICachedProductsRepository
    {
        Task<IEnumerable<Product>> GetCachedProducts();
    }
}
