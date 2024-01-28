using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;

namespace EventApi.Application.Contract
{
    public interface ISubContractorRepository : IAsyncRepository<SubContractors>
    {
        Task<bool> ExistESubContractor(string name);
        Task<int> GetCount(SubContractorFilter filter);
        Task<List<SubContractors>> GetPaged(SubContractorFilter filter, int page);
    }
}
