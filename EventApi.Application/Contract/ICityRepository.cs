using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface ICityRepository : IAsyncRepository<City>
    {
        Task<bool> ExistCity(string name);
    }
}
