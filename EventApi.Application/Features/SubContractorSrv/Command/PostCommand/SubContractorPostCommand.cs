using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Command.PostCommand
{
    public class SubContractorPostCommand : IRequest<ApiResponse<SubContractorPostCommandDto>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
