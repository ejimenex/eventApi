using EventApi.Domain.Entities.Catalog;

namespace EventApi.Application.Contract
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Task<bool> ExistId(int id);
    }
}
