using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Command
{
    public class OcupationPostCommand : IRequest<ApiResponse<OcupationrPostCommandDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
