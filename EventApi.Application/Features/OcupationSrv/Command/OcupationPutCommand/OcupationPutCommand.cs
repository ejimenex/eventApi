using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Command.OcupationPutCommand
{
    public class OcupationPutCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
