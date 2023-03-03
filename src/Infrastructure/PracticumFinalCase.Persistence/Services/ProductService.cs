using AutoMapper;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Application.Dtos.Common;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.Services
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        private readonly IMapper mapper;
        private readonly ICachedProductsRepository cachedProductsRepository;

        public ProductService(IGenericRepository<Product> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, ICachedProductsRepository cachedProductsRepository) : base(genericRepository, mapper, unitOfWork)
        {
            this.mapper = mapper;
            this.cachedProductsRepository = cachedProductsRepository;
        }

        public override async Task<BaseResponse<IEnumerable<ProductDto>>> GetAllAsync()
        {
            IEnumerable<Product> products = await cachedProductsRepository.GetCachedProducts();

            var mapped = mapper.Map<IEnumerable<ProductDto>>(products);

            return new BaseResponse<IEnumerable<ProductDto>>(mapped);
        }
    }
}
