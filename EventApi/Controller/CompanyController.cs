using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary ="fdgfdgfdgfdgfd",Description ="sdgfgf")]
        public async Task<ActionResult<ApiResponse<CompanyResposeDto>>> Create(CompanyPostCommand dto) => Ok(await mediator.Send(dto));
    }
}
