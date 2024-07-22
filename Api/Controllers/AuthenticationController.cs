using Application.UseCase.Security.Authentication.Commands.SingIn;
using Application.UseCase.Security.Authentication.Commands.SignUp;
using Application.UseCase.Security.Authentication.Commands.SignOut;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain.Exceptions;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("SignIn")]
        public async Task<ActionResult> SingIn(AuthenticationCommand authenticationCommand)
        {
            return Ok(await _mediator.Send(authenticationCommand));
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SingUp(SignUpCommand signUpCommand)
        {
            return Ok(await _mediator.Send(signUpCommand));
        }

        [HttpPost("SignOut")]
        public async Task<ActionResult> SingOut()
        {
            var sessionId = User.FindFirst("Session")!.Value ?? throw new NoContentException("Session No Defined");
            return Ok(await _mediator.Send(new SignOutCommand(Guid.Parse(sessionId))));
        }
    }
}
