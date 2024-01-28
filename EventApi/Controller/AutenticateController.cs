using EventApi.Application.Features.AuthenticationSrv.Autenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<TokenResponse>> Create(AutenticateCommand dto) => Ok(await mediator.Send(dto));
    }
}
