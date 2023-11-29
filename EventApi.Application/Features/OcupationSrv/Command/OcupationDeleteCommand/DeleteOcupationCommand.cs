using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Command.OcupationDeleteCommand
{
    public class DeleteOcupationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
