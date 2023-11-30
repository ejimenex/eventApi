using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;

namespace EventApi.Application.Contract
{
    public interface IActivitiesEventsRepository : IAsyncRepository<ActivitiesEvents>
    {
    }
}
