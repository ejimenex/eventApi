using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPut
{
    public class ActivitiesPutCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
    }
    public class ActivitiesPutCommandHandler : IRequestHandler<ActivitiesPutCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IActivitiesEventsRepository _activitiesEeventRepository;
        public ActivitiesPutCommandHandler(IMapper mapper, IActivitiesRepository activitiesRepository, IActivitiesEventsRepository activitiesEventsRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
            _activitiesEeventRepository = activitiesEventsRepository;
        }
        public async Task<Unit> Handle(ActivitiesPutCommand request, CancellationToken cancellationToken)
        {
            var entity = await _activitiesRepository.GetByIdAsync(request.Id);
            var status = entity.StatusId;
            _mapper.Map(request, entity, typeof(ActivitiesPutCommand), typeof(Activities));
            await _activitiesRepository.UpdateAsync(entity);
            await AddEvents(request, status);
            return Unit.Value;
        }
        private async Task AddEvents(ActivitiesPutCommand request, int status)
        {
            if (request.StatusId != status)
            {
                await _activitiesEeventRepository.AddAsync(new ActivitiesEvents
                {
                    ActivitieId = request.Id,
                    StatusId = request.StatusId
                });
            }
        }
    }
}
