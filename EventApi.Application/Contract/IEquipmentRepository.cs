using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Filters;

namespace EventApi.Application.Contract
{
    public interface IEquipmentRepository:IAsyncRepository<Equipment>
    {
        Task<bool> ExistEquipent(string name);
        Task<int> GetCount(EquipmentFilter filter);
        Task<List<Equipment>> GetPaged(EquipmentFilter filter, int page, int size);
    }
}
