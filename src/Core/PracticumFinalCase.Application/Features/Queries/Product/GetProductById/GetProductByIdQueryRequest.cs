using MediatR;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryRequest:IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; set; }
    }
}
