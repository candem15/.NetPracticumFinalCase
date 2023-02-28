using MediatR;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; set; }
        public ProductDto Dto { get; set; }
    }
}
