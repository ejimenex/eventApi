using EventApi.Application.Features.AuthenticationSrv.Autenticate;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<TokenResponse>> Create(AutenticateCommand dto) => Ok(await _mediator.Send(dto));
    }
}
