using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using MediatR;

namespace EventApi.Application.Features.OcupationSrv.Queries.GetAllAsync
{
    public class GetAllAsyncOcupationrQuery : IRequest<GetAllOcupationVM>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public OcupationFilter Filters { get; set; }
    }
    public class GetAllAsyncOcupationQueryHandle(IOcupationRepository _repositoryFactory, IMapper _mapper) : IRequestHandler<GetAllAsyncOcupationrQuery, GetAllOcupationVM>
    {
        public async Task<GetAllOcupationVM> Handle(GetAllAsyncOcupationrQuery request, CancellationToken cancellationToken)
        {

            var list = await _repositoryFactory.GetPaged(request.Filters, request.Page, request.Size);
            var count = await _repositoryFactory.GetCount(request.Filters);
            var data = _mapper.Map<List<GetAllOcupationDto>>(list);

            return new GetAllOcupationVM()
            {
                Count = count,
                Size = request.Size > 10 ? 10 : request.Size,
                Page = request.Page < 1 ? 1 : request.Page,
                Data = data
            };
        }
    }
}
