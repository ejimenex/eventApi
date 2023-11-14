using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
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


        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(c => c.Email == email && !c.IsDeleted);
        }
    }
}
