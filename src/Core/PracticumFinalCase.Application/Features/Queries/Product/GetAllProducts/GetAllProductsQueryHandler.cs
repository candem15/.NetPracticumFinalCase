using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, BaseResponse<IEnumerable<ProductDto>>>
    {
        private readonly IProductService productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<BaseResponse<IEnumerable<ProductDto>>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await productService.GetAllAsync();

            return result;
        }
    }
}
