using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;

namespace EventApi.Application.Contract
{
    public interface IOcupationRepository : IAsyncRepository<Ocupation>
    {
        Task<bool> ExistOcupation(string name);
        Task<int> GetCount(OcupationFilter filter);
        Task<List<Ocupation>> GetPaged(OcupationFilter filter, int page, int size);
    }
}
