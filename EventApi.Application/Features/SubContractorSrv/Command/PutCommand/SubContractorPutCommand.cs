using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Command.PutCommand
{
    public class SubContractorPutCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
