using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductService productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<BaseResponse<ProductDto>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await productService.InsertAsync(request.dto);

            return result;
        }

    }
}
