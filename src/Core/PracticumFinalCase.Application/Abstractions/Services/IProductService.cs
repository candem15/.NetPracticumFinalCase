using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Domain.Models;

namespace PracticumFinalCase.Application.Abstractions.Services
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        
    }
}
