using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Command
{
    public class OcupationPostCommandHandler : IRequestHandler<OcupationPostCommand, ApiResponse<OcupationrPostCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOcupationRepository _ocupationRepository;
        public OcupationPostCommandHandler(IMapper mapper, IOcupationRepository ocupationRepository)
        {
            _mapper = mapper;
            _ocupationRepository = ocupationRepository;
        }

        public async Task<ApiResponse<OcupationrPostCommandDto>> Handle(OcupationPostCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Ocupation>(request);
            var dto = _mapper.Map<OcupationrPostCommandDto>(request);
            await _ocupationRepository.AddAsync(entity);
            return new ApiResponse<OcupationrPostCommandDto> { Success = true, Message = "The ocupation has been inserted", Object = dto };

        }
    }
}
