using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPost
{
    public class ActivitiesPostCommandHanlder(IMapper _mapper, IActivitiesRepository _activitiesRepository, IActivitiesEventsRepository _activitiesEeventRepository) : IRequestHandler<ActivitiesPostCommand, Unit>
    {
        public async Task<Unit> Handle(ActivitiesPostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Activities>(request);
            entity.StatusId = 1;
            var data = await _activitiesRepository.AddAsync(entity);
            await _activitiesEeventRepository.AddAsync(new ActivitiesEvents { ActivitieId = data.Id, StatusId = 1 });
            return Unit.Value;
        }
    }
}
