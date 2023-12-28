using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface IActivitiesEventsRepository : IAsyncRepository<ActivitiesEvents>
    {
    }
}
