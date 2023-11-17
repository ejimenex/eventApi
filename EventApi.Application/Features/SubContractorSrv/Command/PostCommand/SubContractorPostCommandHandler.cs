using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Command.PostCommand
{
    public class SubContractorPostCommandHandler : IRequestHandler<SubContractorPostCommand, ApiResponse<SubContractorPostCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISubContractorRepository _subContractorRepository;
        public SubContractorPostCommandHandler(IMapper mapper, ISubContractorRepository subContractorRepository)
        {
            _mapper = mapper;
            _subContractorRepository = subContractorRepository;
        }

        public async Task<ApiResponse<SubContractorPostCommandDto>> Handle(SubContractorPostCommand request, CancellationToken cancellationToken)
        {

            //var validator = new SubContractorPostCommandValidation(this._subContractorRepository);
            //var validationResult = await validator.ValidateAsync(request);

            //if (validationResult.Errors.Any())
            //{
            //    throw new FriendlyException(validationResult);
            // }

            var entity = _mapper.Map<SubContractors>(request);
            var dto = _mapper.Map<SubContractorPostCommandDto>(request);
            await _subContractorRepository.AddAsync(entity);
            return new ApiResponse<SubContractorPostCommandDto> { Success = true, Message = "The subcontractor has been inserted", Object = dto };

        }
    }
}
