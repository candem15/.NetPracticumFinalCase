using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductService productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<BaseResponse<ProductDto>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await productService.UpdateAsync(request.Id, request.Dto);

            return result;
        }
    }
}
