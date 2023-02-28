using MediatR;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; set; }
    }
}
