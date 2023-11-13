using AutoMapper;
using EventApi.Application.Contract;
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

        public Task<ApiResponse<SubContractorPostCommandDto>> Handle(SubContractorPostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
