using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class OcupationRepository : BaseRepository<Ocupation>, IOcupationRepository
    {
        public OcupationRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }

        public override async Task<Ocupation> AddAsync(Ocupation entity)
        {
            entity.TenantId = (await _tokenService.GetTokenData()).TenantId;
            return await base.AddAsync(entity);
        }

        public async Task<bool> ExistOcupation(string name)
        {
            var tenant = (await _tokenService.GetTokenData()).TenantId;
            return await _dbContext.Ocupation.AnyAsync(c => c.Name == name && c.TenantId == tenant);
        }
        private IQueryable<Ocupation> GetIQuerable(OcupationFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.Ocupation.Where(c => !c.IsDeleted && c.TenantId == tenantId)
               .AsQueryable();

            data = !string.IsNullOrEmpty(filter.Name) ? data.Where(c => c.Name.Contains(filter.Name)) : data;
            return data;
        }
        public async Task<List<Ocupation>> GetPaged(OcupationFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
        public async Task<int> GetCount(OcupationFilter filter) => await GetIQuerable(filter).CountAsync();

    }
}
