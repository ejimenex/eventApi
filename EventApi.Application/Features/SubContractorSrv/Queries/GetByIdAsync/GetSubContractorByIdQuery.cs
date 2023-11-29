using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Queries.GetByIdAsync
{
    public class GetSubContractorByIdQuery : IRequest<SubContractorByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetSubContractorByIdQueryHandler : IRequestHandler<GetSubContractorByIdQuery, SubContractorByIdDto>
    {
        private readonly ISubContractorRepository _subContractorRepository;
        private readonly IMapper _mapper;
        public GetSubContractorByIdQueryHandler(ISubContractorRepository subContractorRepository, IMapper mapper)
        {
            _subContractorRepository = subContractorRepository;
            _mapper = mapper;
        }
        public async Task<SubContractorByIdDto> Handle(GetSubContractorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _subContractorRepository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new CustomException("There is not subcontractor with this Id");
            return _mapper.Map<SubContractorByIdDto>(entity);
        }
    }
}
