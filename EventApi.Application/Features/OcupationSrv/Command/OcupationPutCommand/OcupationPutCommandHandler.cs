using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Features.OcupationSrv.Command.OcupationPutCommand;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Command.PutCommand
{
    public class OcupationPutCommandHandler : IRequestHandler<OcupationPutCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IOcupationRepository _ocupationRepository;
        public OcupationPutCommandHandler(IMapper mapper, IOcupationRepository ocupationRepository)
        {
            _mapper = mapper;
            _ocupationRepository = ocupationRepository;
        }
        public async Task<Unit> Handle(OcupationPutCommand request, CancellationToken cancellationToken)
        {
            var entity = await _ocupationRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, entity, typeof(OcupationPutCommand), typeof(Ocupation));
            await _ocupationRepository.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
