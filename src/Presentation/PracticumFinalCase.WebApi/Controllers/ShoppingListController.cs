using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByTitle;
using PracticumFinalCase.Application.Response;
using Serilog;
using System.Net;

namespace PracticumFinalCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShoppingListController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin,basicUser")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<ShoppingListDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShoppingListsByTitleAsync([FromQuery] GetShoppingListsByTitleQueryRequest request)
        {
            ValidationResult validationResult = new GetShoppingListsByTitleQueryRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new BaseResponse<IEnumerable<ShoppingListDto>>(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var result = await mediator.Send(request);

            Log.Debug("ShoppingListController.GetShoppingListsByTitleAsync");
            return Ok(result);
        }

        //[HttpGet("{Id}")]
        //[Authorize]
        //[ProducesResponseType(typeof(BaseResponse<ProductDto>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //public async Task<IActionResult> GetByIdAsync([FromRoute] GetProductByIdQueryRequest request)
        //{
        //    var result = await mediator.Send(request);

        //    if (result.Success)
        //    {
        //        Log.Debug("ProductController.GetByIdAsync");
        //        return Ok(result);
        //    }
        //    return Unauthorized();
        //}

        //[HttpPost]
        //[Authorize]
        //[ProducesResponseType(typeof(BaseResponse<NoContentResult>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommandRequest request)
        //{
        //    var result = await mediator.Send(request);

        //    if (result.Success)
        //    {
        //        Log.Debug("ProductController.CreateAsync");
        //        return Ok(result);
        //    }
        //    return Unauthorized();
        //}

        //[HttpPut]
        //[Authorize]
        //[ProducesResponseType(typeof(BaseResponse<NoContentResult>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommandRequest request)
        //{
        //    var result = await mediator.Send(request);

        //    if (result.Success)
        //    {
        //        Log.Debug("ProductController.UpdateAsync");
        //        return Ok(result);
        //    }
        //    return Unauthorized();
        //}

        //[HttpDelete("{Id}")]
        //[Authorize]
        //[ProducesResponseType(typeof(BaseResponse<>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //public async Task<IActionResult> DeleteAsync([FromRoute] DeleteProductCommandRequest request)
        //{
        //    var result = await mediator.Send(request);

        //    if (result.Success)
        //    {
        //        Log.Debug("ProductController.DeleteAsync");
        //        return Ok(result);
        //    }
        //    return Unauthorized();
        //}

    }
}
