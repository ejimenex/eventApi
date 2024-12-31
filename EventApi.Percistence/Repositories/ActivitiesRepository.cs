using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Extension;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesRepository(EventApiDbContext context, ITokenService token) : BaseRepository<Activities>(context, token), IActivitiesRepository
    {
        public async Task<int> GetCount(ActivitiesFilter filter)
        {
            return await GetIQuerable(filter).CountAsync();
        }

        public async Task<List<Activities>> GetPaged(ActivitiesFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .PaginateResult(page, size)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }

        private IQueryable<Activities> GetIQuerable(ActivitiesFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.Activities
                .Where(c => !c.IsDeleted && c.TenantId == tenantId)
                .WhereIf(!string.IsNullOrEmpty(filter.name), c => c.Name.Trim().ToUpper().Contains(filter.name.Trim().ToUpper()))
                .WhereIf(filter.status.HasValue, c => c.StatusId == filter.status.Value)
                .WhereIf(filter.dateFrom is not null && filter.dateTo is not null, c => c.CreatedDate >= filter.dateFrom && c.CreatedDate <= filter.dateTo)
                .Include(c => c.Statu)
                .Include(c=> c.City)
                .OrderByDescending(c => c.Id)
               .AsQueryable();

            return data;
        }
    }
}
