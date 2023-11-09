using EventApi.Application.Features.CountrySrv.Queries.GetAllAsync;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetCountriesDto>>> Get() => Ok(await _mediator.Send(new GetAllCountriesQuery()));
    }
}
