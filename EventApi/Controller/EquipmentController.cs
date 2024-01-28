using EventApi.Application.Features.EquipmentSrv.Command.PostCommand;
using EventApi.Application.Features.EquipmentSrv.Command.PutCommand;
using EventApi.Application.Features.EquipmentSrv.Queries.GetAllAsync;
using EventApi.Application.Features.EquipmentSrv.Queries.GetByIdAsync;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController(IMediator mediator) : ControllerBase
    {
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(EquipmentPutCommand dto)
        {
            await mediator.Send(dto);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<Result<IReadOnlyList<Equipment>>>> GetAll([FromQuery] GetAllAsyncEquipmentQuery query)
        {
            return Ok(await mediator.Send(query));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentByIdDto>> GetById(int id) => Ok(await mediator.Send(new GetEquipmentByIdQuery { Id = id }));
        [HttpGet("GetPaged")]
        public async Task<ActionResult<GetAllEquipmentVM>> GetPaged([FromQuery] EquipmentFilter filter, int page = 1, int size = 10) =>
        Ok(await mediator.Send(new GetAllAsyncEquipmentQuery() { Filters = filter, Page = page, Size = size }));

        [HttpPost]
        public async Task<ActionResult<ApiResponse<EquipmentPostCommandDto>>> Create(EquipmentPostCommand dto) => Ok(await mediator.Send(dto));
    }
}
