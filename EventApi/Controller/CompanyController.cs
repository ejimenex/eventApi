using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<CompanyResposeDto>>> Create(CompanyPostCommand dto) => Ok(await mediator.Send(dto));
    }
}
