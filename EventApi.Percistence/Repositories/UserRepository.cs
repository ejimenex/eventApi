using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EventApiDbContext context) : base(context)
        {

        }

        public async Task<bool> ExistEmail(string email)
        {
            return await _dbContext.User.AnyAsync(c=> c.Email==email && !c.IsDeleted);
        }
    }
}
