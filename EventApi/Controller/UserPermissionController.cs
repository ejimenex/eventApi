using EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserDelete;
using EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController(IMediator mediator) : ControllerBase
    {
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id) => Ok(await mediator.Send(new PermissionUserDeleteCommand { Id = id }));
        [HttpPost]
        public async Task<ActionResult<bool>> Save(PermissionUserPostCommand dto) => Ok(await mediator.Send(dto));
    }
}
