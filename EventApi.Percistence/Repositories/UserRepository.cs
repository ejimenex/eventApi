using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }

        public async Task<bool> ExistEmail(string email)
        {
            return await _dbContext.User.AnyAsync(c => c.Email == email && !c.IsDeleted);
        }
        private IQueryable<User> GetIQuerable(UserFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.User.Where(c => !c.IsDeleted && c.TenantId == tenantId)
                .Include(c=> c.Ocupation)
               .AsQueryable();

            data = filter.OcupationId is not null ? data.Where(c => c.OcupationId == filter.OcupationId) : data;
            data = !string.IsNullOrEmpty(filter.FullName) ? data.Where(c => c.FullName.Contains(filter.FullName)) : data;
            return data;
        }
        public async Task<List<User>> GetPaged(UserFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
        public async Task<int> GetCount(UserFilter filter) => await GetIQuerable(filter).CountAsync();

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(c => c.Email == email && !c.IsDeleted);
        }
    }
}
