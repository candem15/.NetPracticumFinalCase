using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductService productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<BaseResponse<ProductDto>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await productService.GetByIdAsync(request.Id);

            return result;
        }
    }
}
