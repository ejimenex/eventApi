using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<bool> ExistCompany(string name);
    }
}
