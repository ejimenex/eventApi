using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetById
{
    public class GetActivitiyByIdQuery : IRequest<GetActivitiesByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetActivitiyByIdQueryHandler : IRequestHandler<GetActivitiyByIdQuery, GetActivitiesByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        public GetActivitiyByIdQueryHandler(IMapper mapper, IActivitiesRepository activitiesRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
        }

        public async Task<GetActivitiesByIdDto> Handle(GetActivitiyByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _activitiesRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetActivitiesByIdDto>(entity);
        }
    }

}
