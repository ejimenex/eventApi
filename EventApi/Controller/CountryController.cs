using EventApi.Application.Features.CountrySrv.Queries.GetAllAsync;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetCountriesDto>>> Get() => Ok(await mediator.Send(new GetAllCountriesQuery()));
    }
}
