using Application.UseCase.Security.Authentication.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IMediator _mediator) : ControllerBase
    {

        [HttpPost(Name = "SingIn")]
        public async Task<ActionResult> SingIn(AuthenticationCommand authenticationCommand)
        {
            return Ok(await _mediator.Send(authenticationCommand));
        }
    }
}
