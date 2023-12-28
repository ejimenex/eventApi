using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesRepository : BaseRepository<Activities>, IActivitiesRepository
    {
        public ActivitiesRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }

        public async Task<int> GetCount(ActivitiesFilter filter)
        {
            return await GetIQuerable(filter).CountAsync();
        }

        public async Task<List<Activities>> GetPaged(ActivitiesFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }

        private IQueryable<Activities> GetIQuerable(ActivitiesFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.Activities
                .Where(c => !c.IsDeleted && c.TenantId == tenantId)
                .Include(c => c.Statu)
                .OrderByDescending(c => c.Id)
               .AsQueryable();

            data = !string.IsNullOrEmpty(filter.name) ? data.Where(c => c.Name.Contains(filter.name)) : data;
            data = filter.status.HasValue ? data.Where(c => c.StatusId == filter.status.Value) : data;
            data = filter.dateFrom is not null && filter.dateTo is not null ? data.Where(c => c.CreatedDate >= filter.dateFrom && c.CreatedDate <= filter.dateTo) : data;
            return data;
        }
    }
}
