using EventApi.Domain.Entities;

namespace EventApi.Application.Contract
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Task<bool> ExistId(int id);
    }
}
