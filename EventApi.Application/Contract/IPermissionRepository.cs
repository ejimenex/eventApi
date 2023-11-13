using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetPermission();
    }
}
