using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Infrasestructure.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<CompanyResposeDto>>> Create(CompanyPostCommand dto) => Ok(await _mediator.Send(dto));
    }
}
