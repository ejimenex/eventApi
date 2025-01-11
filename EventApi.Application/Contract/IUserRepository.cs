using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Filters;

namespace EventApi.Application.Contract
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<bool> ExistEmail(string email);
        Task<User> GetByEmail(string email);
        Task<(List<User>,int)> GetPaged(UserFilter filter, int page, int size);
        Task<int> GetCount(UserFilter filter);
    }
}
