using EventApi.Application.Features.PermissionSrv.Queries.PermissionAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<PemissionAllDto>>> Get() => Ok(await _mediator.Send(new PermissionAllQuery()));
    }
}
