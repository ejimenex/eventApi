using EventApi.Application.Features.OcupationSrv.Command;
using EventApi.Application.Features.OcupationSrv.Command.OcupationDeleteCommand;
using EventApi.Application.Features.OcupationSrv.Command.OcupationPutCommand;
using EventApi.Application.Features.OcupationSrv.Queries.GetAllAsync;
using EventApi.Application.Features.OcupationSrv.Queries.GetByIdAsync;
using EventApi.Infrasestructure.Filters;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcupationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OcupationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(OcupationPutCommand dto)
        {
            await _mediator.Send(dto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOcupationByIdDto>> GetById(int id) => Ok(await _mediator.Send(new GetOcupationByIdQuery { Id = id }));
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id) => Ok(await _mediator.Send(new DeleteOcupationCommand { Id = id }));

        [HttpGet("GetPaged")]
        public async Task<ActionResult<GetAllOcupationVM>> GetPaged([FromQuery] OcupationFilter filter, int page = 1, int size = 10) =>
        Ok(await _mediator.Send(new GetAllAsyncOcupationrQuery() { Filters = filter, Page = page, Size = size }));

        [HttpPost]
        public async Task<ActionResult<ApiResponse<OcupationrPostCommandDto>>> Create(OcupationPostCommand dto) => Ok(await _mediator.Send(dto));
    }
}
