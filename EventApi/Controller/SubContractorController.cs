using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Application.Features.SubContractorSrv.Command.PostCommand;
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
        [HttpPost]
        public async Task<ActionResult<ApiResponse<SubContractorPostCommandDto>>> Create(SubContractorPostCommand dto) => Ok(await _mediator.Send(dto));
    }
}
