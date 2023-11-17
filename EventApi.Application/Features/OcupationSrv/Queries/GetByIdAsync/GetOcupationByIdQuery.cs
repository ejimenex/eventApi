using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Queries.GetByIdAsync
{
    public class GetOcupationByIdQuery : IRequest<GetOcupationByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetOcupationByIdQueryHandler : IRequestHandler<GetOcupationByIdQuery, GetOcupationByIdDto>
    {
        private readonly IOcupationRepository _repositoryFactory;
        private readonly IMapper _mapper;
        public GetOcupationByIdQueryHandler(IOcupationRepository repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<GetOcupationByIdDto> Handle(GetOcupationByIdQuery request, CancellationToken cancellationToken)
        {

            var one = await this._repositoryFactory.GetByIdAsync(request.Id);
            return _mapper.Map<GetOcupationByIdDto>(one);
        }
    }
}
