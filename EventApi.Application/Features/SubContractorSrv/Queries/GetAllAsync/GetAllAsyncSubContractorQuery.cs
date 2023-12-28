using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using MediatR;

namespace EventApi.Application.Features.SubContractorSrv.Queries.GetAllAsync
{
    public class GetAllAsyncSubContractorQuery : IRequest<GetAllSubContractorVM>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public SubContractorFilter Filters { get; set; }
    }
    public class GetAllAsyncSubContractorQueryHandle(ISubContractorRepository _repositoryFactory, IMapper _mapper) : IRequestHandler<GetAllAsyncSubContractorQuery, GetAllSubContractorVM>
    {
        public async Task<GetAllSubContractorVM> Handle(GetAllAsyncSubContractorQuery request, CancellationToken cancellationToken)
        {

            var list = await _repositoryFactory.GetPaged(request.Filters, request.Page, request.Size);
            var count = await _repositoryFactory.GetCount(request.Filters);
            var data = _mapper.Map<List<GetAllSusContractorDto>>(list);

            return new GetAllSubContractorVM()
            {
                Count = count,
                Size = request.Size > 10 ? 10 : request.Size,
                Page = request.Page < 1 ? 1 : request.Page,
                Data = data
            };
        }
    }
}
