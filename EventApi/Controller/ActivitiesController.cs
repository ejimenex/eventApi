﻿using EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPost;
using EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPut;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetAll;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetById;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesPaged;
using EventApi.Infrasestructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(IMediator mediator) : ControllerBase
    {
        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<GetAllActivitiesDto>> Get()
        {
            return Ok(mediator.Send(new GetAllActivitiesQuery()));
        }
        //[HttpPut]
        //public async Task<ActionResult<Unit>> Update(SubContractorPutCommand dto)
        //{
        //    await _mediator.Send(dto);
        //    return NoContent();
        //}
        //[HttpGet]
        //public async Task<ActionResult<Result<IReadOnlyList<SubContractors>>>> GetAll([FromQuery] GetAllAsyncSubContractorQuery query)
        //{
        //    return Ok(await _mediator.Send(query));
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GetOcupationByIdDto>> GetById(int id) => Ok(await _mediator.Send(new GetSubContractorByIdQuery { Id = id }));
        //[HttpGet("GetPaged")]
        //public async Task<ActionResult<GetAllSubContractorVM>> GetPaged([FromQuery] SubContractorFilter filter, int page = 1, int size = 10) =>
        //    Ok(await _mediator.Send(new GetAllAsyncSubContractorQuery() { Filters = filter, Page = page, Size = size }));

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(ActivitiesPostCommand dto) => Ok(await mediator.Send(dto));

        [HttpPut]
        public async Task<ActionResult<Unit>> Update(ActivitiesPutCommand dto) => Ok(await mediator.Send(dto));

        [HttpGet("{id}")]
        public async Task<ActionResult<GetActivitiesByIdDto>> GetPaged(int id) =>
        Ok(await mediator.Send(new GetActivitiyByIdQuery() { Id = id }));
        [HttpGet]
        [Route("GetPaged")]
        public async Task<ActionResult<GetActivitiesPagedVM>> GetPaged([FromQuery] ActivitiesFilter filter, int page = 1, int size = 10) =>
        Ok(await mediator.Send(new GetActivitiesPagedQuery() { Filter = filter, Page = page, Size = size }));
    }
}
