using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class PermissionUserRepository : IPermissionUserRepository
    {
        private readonly EventApiDbContext _context;
        public PermissionUserRepository(EventApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<PermissionUser>> GetByUser(int id)
        {
            return await _context.PermissionUser.Where(c => c.UserId == id).ToListAsync();
        }
        public async Task Add(PermissionUser user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(int id)
        {
            _context.Remove(await _context.PermissionUser.FindAsync(id));
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistUser(int id) => await _context.User.AnyAsync(c => c.Id == id && !c.IsDeleted);

        public async Task<bool> ExistScope(string scope) => await _context.Permission.AnyAsync(c => c.Scope == scope);
        public async Task<bool> ExistId(int Id) => await _context.PermissionUser.AnyAsync(c => c.Id == Id);
        public async Task<bool> Exist(int userId, string scope) => !await _context.PermissionUser.AnyAsync(c => c.UserId == userId && c.PermissionScope == scope);

    }
}
