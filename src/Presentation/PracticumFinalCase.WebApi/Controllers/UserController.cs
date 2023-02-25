using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Features.Commands.User.LoginUser;

namespace PracticumFinalCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            var response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
    }
}
