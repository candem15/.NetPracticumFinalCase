using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Features.Commands.Product.CreateProduct;
using PracticumFinalCase.Application.Features.Commands.Product.DeleteProduct;
using PracticumFinalCase.Application.Features.Commands.Product.UpdateProduct;
using PracticumFinalCase.Application.Features.Queries.Product.GetAllProducts;
using PracticumFinalCase.Application.Features.Queries.Product.GetProductById;
using PracticumFinalCase.Application.Response;
using Serilog;
using System.Net;

namespace PracticumFinalCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<ProductDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllProductsQueryRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ProductController.GetAllAsync");
                return Ok(result);
            }

            return Unauthorized();
        }

        [HttpGet("{Id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ProductDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetProductByIdQueryRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ProductController.GetByIdAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NoContentResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommandRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ProductController.CreateAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NoContentResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommandRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ProductController.UpdateAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute]DeleteProductCommandRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ProductController.DeleteAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

    }
}
