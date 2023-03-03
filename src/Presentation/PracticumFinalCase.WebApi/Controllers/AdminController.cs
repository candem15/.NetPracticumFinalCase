using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingLists;
using PracticumFinalCase.Application.Response;
using Serilog;
using System.Net;

namespace PracticumFinalCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("CompletedShoppingLists")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<ShoppingListEventDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShoppingListsAsync([FromQuery] GetShoppingListsQueryRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Debug("ShoppingListController.GetShoppingListsByTitleAsync");
                return Ok(result);
            }

            return BadRequest(new BaseResponse<BadRequestResult>("Error occured while getting shopping lists."));
        }
    }
}
