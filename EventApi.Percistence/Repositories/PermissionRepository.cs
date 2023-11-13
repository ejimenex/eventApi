using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly EventApiDbContext _context;
        public PermissionRepository(EventApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Permission>> GetPermission()
        {
            return await _context.Permission.ToListAsync();
        }
    }
}
