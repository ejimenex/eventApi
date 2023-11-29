using EventApi.Application.Contract.Persistence;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesPaged;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;

namespace EventApi.Application.Contract
{
    public interface IActivitiesRepository : IAsyncRepository<Activities>
    {
        Task<List<Activities>> GetPaged(ActivitiesFilter filter, int page, int size);
        Task<int> GetCount(ActivitiesFilter filter);
    }
}
