using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPost
{
    public class ActivitiesPostCommandHanlder : IRequestHandler<ActivitiesPostCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IActivitiesEventsRepository _activitiesEeventRepository;
        public ActivitiesPostCommandHanlder(IMapper mapper, IActivitiesRepository activities, IActivitiesEventsRepository activitiesEeventRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activities;
            _activitiesEeventRepository = activitiesEeventRepository;

        }

        public async Task<Unit> Handle(ActivitiesPostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Activities>(request);
            entity.StatusId = 1;
            var data= await _activitiesRepository.AddAsync(entity);
            await _activitiesEeventRepository.AddAsync(new ActivitiesEvents { ActivitieId=data.Id,StatusId=1});
            return Unit.Value;
        }
    }
}
