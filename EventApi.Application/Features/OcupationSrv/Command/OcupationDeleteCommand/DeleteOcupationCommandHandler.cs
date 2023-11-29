using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Command.OcupationDeleteCommand
{
    public class DeleteOcupationCommandHandler : IRequestHandler<DeleteOcupationCommand, Unit>
    {
        private readonly IOcupationRepository _ocupationRepository;
        public DeleteOcupationCommandHandler(IOcupationRepository ocupationRepository)
        {
            _ocupationRepository = ocupationRepository;
        }

        public async Task<Unit> Handle(DeleteOcupationCommand request, CancellationToken cancellationToken)
        {
            var data = await _ocupationRepository.GetByIdAsync(request.Id);
            data.IsDeleted = true;
            await _ocupationRepository.UpdateAsync(data);
            return Unit.Value;
        }
    }
}
