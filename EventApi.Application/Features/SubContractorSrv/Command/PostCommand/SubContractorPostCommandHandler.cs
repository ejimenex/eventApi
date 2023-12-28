using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Command.PostCommand
{
    public class SubContractorPostCommandHandler(IMapper _mapper, ISubContractorRepository _subContractorRepository) : IRequestHandler<SubContractorPostCommand, ApiResponse<SubContractorPostCommandDto>>
    {


        public async Task<ApiResponse<SubContractorPostCommandDto>> Handle(SubContractorPostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubContractors>(request);
            var dto = _mapper.Map<SubContractorPostCommandDto>(request);
            await _subContractorRepository.AddAsync(entity);
            return new ApiResponse<SubContractorPostCommandDto> { Success = true, Message = "The subcontractor has been inserted", Object = dto };

        }
    }
}
