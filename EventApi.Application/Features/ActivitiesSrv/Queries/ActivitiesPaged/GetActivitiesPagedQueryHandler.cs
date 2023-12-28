
using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesPaged
{
    public class GetActivitiesPagedQueryHandler(IMapper _mapper, IActivitiesRepository _activitiesRepository) : IRequestHandler<GetActivitiesPagedQuery, GetActivitiesPagedVM>
    {


        public async Task<GetActivitiesPagedVM> Handle(GetActivitiesPagedQuery request, CancellationToken cancellationToken)
        {
            var list = await _activitiesRepository.GetPaged(request.Filter, request.Page, request.Size);
            var count = await _activitiesRepository.GetCount(request.Filter);
            var data = _mapper.Map<List<GetActivitiesPagesDto>>(list);

            return new GetActivitiesPagedVM()
            {
                Count = count,
                Size = request.Size > 10 ? 10 : request.Size,
                Page = request.Page < 1 ? 1 : request.Page,
                Data = data
            };
        }
    }
}
