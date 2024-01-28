using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Command
{
    public class OcupationPostCommandHandler(IMapper mapper, IOcupationRepository ocupationRepository) : IRequestHandler<OcupationPostCommand, ApiResponse<OcupationrPostCommandDto>>
    {
        public async Task<ApiResponse<OcupationrPostCommandDto>> Handle(OcupationPostCommand request, CancellationToken cancellationToken)
        {

            var entity = mapper.Map<Ocupation>(request);
            var dto = mapper.Map<OcupationrPostCommandDto>(request);
            await ocupationRepository.AddAsync(entity);
            return new ApiResponse<OcupationrPostCommandDto> { Success = true, Message = "The ocupation has been inserted", Object = dto };

        }
    }
}
