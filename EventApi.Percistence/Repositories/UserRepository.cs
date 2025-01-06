using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Extension;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class UserRepository(EventApiDbContext context, ITokenService token) : BaseRepository<User>(context, token), IUserRepository
    {
        public async Task<bool> ExistEmail(string email)
        {
            return await _dbContext.User.AnyAsync(c => c.Email == email && !c.IsDeleted);
        }
        private IQueryable<User> GetIQuerable(UserFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            return _dbContext.User.Where(c => !c.IsDeleted && c.TenantId == tenantId)
                .WhereIf(filter.OcupationId is not null, c => c.OcupationId == filter.OcupationId)
                .WhereIf(!string.IsNullOrEmpty(filter.FullName), c => c.FullName.Contains(filter.FullName))
                .Include(c => c.Ocupation)
               .AsQueryable();
        }
        public async Task<(List<User>,int)> GetPaged(UserFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .PaginateResult(page, size)
                .ToListAsync();
            return (result,data.Count() );
        }
        public async Task<int> GetCount(UserFilter filter) => await GetIQuerable(filter).CountAsync();

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(c => c.Email == email && !c.IsDeleted);
        }
    }
}
