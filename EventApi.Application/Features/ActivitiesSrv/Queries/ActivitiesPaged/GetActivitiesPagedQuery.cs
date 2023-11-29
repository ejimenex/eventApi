using EventApi.Infrasestructure.Filters;
using MediatR;

namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesPaged
{
    public class GetActivitiesPagedQuery : IRequest<GetActivitiesPagedVM>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public ActivitiesFilter Filter { get; set; }
    }
}
