using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetAll
{
    public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, IQueryable<GetAllActivitiesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        public GetAllActivitiesQueryHandler(IMapper mapper, IActivitiesRepository activitiesRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
        }

        public async Task<IQueryable<GetAllActivitiesDto>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            var list = _activitiesRepository.ListAllDataBaseAsync();
            return _mapper.ProjectTo<GetAllActivitiesDto>(list);
        }
    }
}
