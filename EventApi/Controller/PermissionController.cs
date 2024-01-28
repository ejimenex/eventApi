using EventApi.Application.Features.PermissionSrv.Queries.PermissionAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PemissionAllDto>>> Get() => Ok(await mediator.Send(new PermissionAllQuery()));
    }
}
