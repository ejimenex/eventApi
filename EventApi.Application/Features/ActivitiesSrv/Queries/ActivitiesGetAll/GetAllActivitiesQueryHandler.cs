using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetAll
{
    public class GetAllActivitiesQueryHandler(IMapper _mapper, IActivitiesRepository _activitiesRepository) : IRequestHandler<GetAllActivitiesQuery, IQueryable<GetAllActivitiesDto>>
    {

        public async Task<IQueryable<GetAllActivitiesDto>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            var list = _activitiesRepository.ListAllDataBaseAsync();
            return _mapper.ProjectTo<GetAllActivitiesDto>(list);
        }
    }
}
