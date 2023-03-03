using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticumFinalCase.Application.Features.Commands.User.CreateUser;
using PracticumFinalCase.Application.Features.Commands.User.LoginUser;
using PracticumFinalCase.Application.Features.Commands.User.ResetUserPassword;
using PracticumFinalCase.Application.Response;
using Serilog;
using System.Net;

namespace PracticumFinalCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommandRequest request)
        {
            ValidationResult validationResult = new CreateUserCommandRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new BaseResponse<BadRequestResult>(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var result = await mediator.Send(request);

            Log.Debug("UserController.CreateAsync");
            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<BadRequestResult>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetUserPasswordCommandRequest request)
        {
            ValidationResult validationResult = new ResetUserPasswordCommandRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new BaseResponse<BadRequestResult>(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var result = await mediator.Send(request);

            Log.Debug("UserController.ResetPasswordAsync");
            return Ok(result);
        }

    }
}
