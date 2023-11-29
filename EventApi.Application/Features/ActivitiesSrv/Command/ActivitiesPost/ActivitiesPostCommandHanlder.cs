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
        public ActivitiesPostCommandHanlder(IMapper mapper, IActivitiesRepository activities)
        {
            _mapper = mapper;
            _activitiesRepository = activities;
        }

        public async Task<Unit> Handle(ActivitiesPostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Activities>(request);
            entity.StatusId = 1;
            await _activitiesRepository.AddAsync(entity);
            return Unit.Value;
        }
    }
}
