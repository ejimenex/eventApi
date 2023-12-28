using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using MediatR;

namespace EventApi.Application.Features.EquipmentSrv.Queries.GetAllAsync
{
    public class GetAllAsyncEquipmentQuery : IRequest<GetAllEquipmentVM>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public EquipmentFilter Filters { get; set; }
    }
    public class GetAllAsyncSubContractorQueryHandle(IEquipmentRepository _repositoryFactory, IMapper _mapper) : IRequestHandler<GetAllAsyncEquipmentQuery, GetAllEquipmentVM>
    {

        public async Task<GetAllEquipmentVM> Handle(GetAllAsyncEquipmentQuery request, CancellationToken cancellationToken)
        {

            var list = await _repositoryFactory.GetPaged(request.Filters, request.Page, request.Size);
            var count = await _repositoryFactory.GetCount(request.Filters);
            var data = _mapper.Map<List<GetAllEquipmentDto>>(list);

            return new GetAllEquipmentVM()
            {
                Count = count,
                Size = request.Size > 10 ? 10 : request.Size,
                Page = request.Page < 1 ? 1 : request.Page,
                Data = data
            };
        }
    }
}
