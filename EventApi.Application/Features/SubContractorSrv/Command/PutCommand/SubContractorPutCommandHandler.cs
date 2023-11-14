using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Command.PutCommand
{
    public class SubContractorPutCommandHandler : IRequestHandler<SubContractorPutCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ISubContractorRepository _subContractorRepository;
        public SubContractorPutCommandHandler(IMapper mapper, ISubContractorRepository subContractor)
        {
            _mapper = mapper;
            _subContractorRepository = subContractor;
        }
        public async Task<Unit> Handle(SubContractorPutCommand request, CancellationToken cancellationToken)
        {
            var entity = await _subContractorRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, entity, typeof(SubContractorPutCommand), typeof(SubContractors));
            await _subContractorRepository.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
