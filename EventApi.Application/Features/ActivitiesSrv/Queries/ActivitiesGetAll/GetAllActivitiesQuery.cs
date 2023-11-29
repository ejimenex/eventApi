using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetAll
{
    public class GetAllActivitiesQuery : IRequest<IQueryable<GetAllActivitiesDto>>
    {
    }
}
