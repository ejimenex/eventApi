using EventApi.Domain.Entities.Security;

namespace EventApi.Application.Contract
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetPermission();
    }
}
