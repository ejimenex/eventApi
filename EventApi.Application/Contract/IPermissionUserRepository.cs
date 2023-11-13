using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface IPermissionUserRepository
    {
        Task<List<PermissionUser>> GetByUser(int id);
        Task Add(PermissionUser user);
        Task Remove(int id);
        Task<bool> ExistUser(int id);
        Task<bool> ExistId(int id);
        Task<bool> ExistScope(string scope);
        Task<bool> Exist(int userId, string scope);
    }
}
