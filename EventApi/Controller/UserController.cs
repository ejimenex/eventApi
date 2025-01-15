using EventApi.Application.Features.UsersSrv.Command.Delete;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Application.Features.UsersSrv.Queries.GetAllUser;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Filters;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetPaged")]
        public async Task<ActionResult<ApiResponse<GetAllUserVM>>> GetPaged([FromQuery] UserFilter filter, int page = 1, int size = 10) =>
           Ok(await mediator.Send(new GetAllUserQuery() { Filters = filter, Page = page, Size = size }));
        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserDto>>> Create(UserCommand dto) => Ok(await mediator.Send(dto));
        [HttpDelete]
        public async Task<ActionResult<ApiResponse<User>>> Delete([FromQuery]DeleteUserCommand dto) => Ok(await mediator.Send(dto));
    }
}
