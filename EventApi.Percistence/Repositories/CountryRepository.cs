using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly EventApiDbContext _context;
        public CountryRepository(EventApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _context.Country.Where(c => c.IsAvaliable).ToListAsync();
        }
        public async Task<bool> ExistId(int id)
        {
            return await _context.Country.AnyAsync(c => c.IsAvaliable && c.Id == id);
        }

    }
}
