using EventApi.Application.Features.OcupationSrv.Queries.GetByIdAsync;
using EventApi.Application.Features.SubContractorSrv.Command.PostCommand;
using EventApi.Application.Features.SubContractorSrv.Command.PutCommand;
using EventApi.Application.Features.SubContractorSrv.Queries.GetAllAsync;
using EventApi.Application.Features.SubContractorSrv.Queries.GetByIdAsync;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubContractorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubContractorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(SubContractorPutCommand dto)
        {
            await _mediator.Send(dto);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<Result<IReadOnlyList<SubContractors>>>> GetAll([FromQuery] GetAllAsyncSubContractorQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOcupationByIdDto>> GetById(int id) => Ok(await _mediator.Send(new GetSubContractorByIdQuery { Id = id }));
        [HttpGet("GetPaged")]
        public async Task<ActionResult<GetAllSubContractorVM>> GetPaged([FromQuery] SubContractorFilter filter, int page = 1, int size = 10) =>
        Ok(await _mediator.Send(new GetAllAsyncSubContractorQuery() { Filters = filter, Page = page, Size = size }));

        [HttpPost]
        public async Task<ActionResult<ApiResponse<SubContractorPostCommandDto>>> Create(SubContractorPostCommand dto) => Ok(await _mediator.Send(dto));
    }
}
