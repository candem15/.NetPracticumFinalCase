using MediatR;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<BaseResponse<ProductDto>>
    {
        public ProductDto dto { get; set; }
    }
}
