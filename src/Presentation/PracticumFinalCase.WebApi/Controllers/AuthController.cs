using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Features.Commands.User.LoginUser;
using PracticumFinalCase.Application.Response;
using Serilog;
using System.Net;

namespace PracticumFinalCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseResponse<TokenDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserCommandRequest request)
        {
            var result = await mediator.Send(request);

            if (result.Success)
            {
                Log.Information($"User: {result.Response.UserName}, Role: {result.Response.Role} is logged in.");
                return Ok(result);
            }

            return Unauthorized();
        }

    }
}
