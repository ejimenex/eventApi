using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface ISubContractorRepository : IAsyncRepository<SubContractors>
    {
        Task<bool> ExistESubContractor(string name);
        Task<int> GetCount();
    }
}
