using MediatR;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductService productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<BaseResponse<ProductDto>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await productService.RemoveAsync(request.Id);

            return result;
        }
    }
}
