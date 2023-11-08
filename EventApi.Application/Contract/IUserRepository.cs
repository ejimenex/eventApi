using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface IUserRepository:IAsyncRepository<User>
    {
         Task<bool> ExistEmail(string email);
    }
}
