using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.CompleteShoppingList;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.CreateShoppingList;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.DeleteShoppingList;
using PracticumFinalCase.Application.Features.Commands.ShoppingList.UpdateShoppingList;
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
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShoppingListsByTitleAsync([FromQuery] GetShoppingListsByTitleQueryRequest request)
        {
            ValidationResult validationResult = new GetShoppingListsByTitleQueryRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new BaseResponse<BadRequestResult>(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var result = await mediator.Send(request);

            Log.Debug("ShoppingListController.GetShoppingListsByTitleAsync");
            return Ok(result);
        }

        [HttpGet("{Id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<object>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CompleteAsync([FromRoute] CompleteShoppingListCommandRequest request)
        {
            if (request.Id < 1)
                return BadRequest(new BaseResponse<BadRequestResult>("InvalidId"));

            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ShoppingListController.CompleteAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateShoppingListCommandRequest request)
        {
            ValidationResult validationResult = new CreateShoppingListCommandRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new BaseResponse<BadRequestResult>(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            
            request.OwnerId = int.Parse(User.FindFirst("AccountId").Value);

            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ShoppingListController.CreateAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateShoppingListCommandRequest request)
        {
            ValidationResult validationResult = new UpdateShoppingListCommandRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new BaseResponse<BadRequestResult>(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ShoppingListController.UpdateAsync");
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpDelete("{Id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<object>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteShoppingListCommandRequest request)
        {
            if (request.Id < 1)
                return BadRequest(new BaseResponse<BadRequestResult>("InvalidId"));

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
