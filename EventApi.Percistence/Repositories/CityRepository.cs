using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class CityRepository(EventApiDbContext context, ITokenService token) : BaseRepository<City>(context, token), ICityRepository
    {
        public async Task<bool> ExistCity(string name)
        {
            var toke = await _tokenService.GetTokenData();
            return await _dbContext.City.AnyAsync(c => c.Name.Trim().ToUpper() == name.Trim().ToUpper() && c.TenantId == toke.TenantId);
        }
       
    }
}
