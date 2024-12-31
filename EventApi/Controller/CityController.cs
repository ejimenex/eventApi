using EventApi.Application.Features.CitySrv.Command.CreateCommand;
using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary ="fdgfdgfdgfdgfd",Description ="sdgfgf")]
        public async Task<ActionResult<ApiResponse<Unit>>> Create(CityPostCommand dto) => Ok(await mediator.Send(dto));
    }
}
