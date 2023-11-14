using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class SubContractorRepository : BaseRepository<SubContractors>, ISubContractorRepository
    {
        public SubContractorRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }

        public override async Task<SubContractors> AddAsync(SubContractors entity)
        {
            entity.TenantId = (await _tokenService.GetTokenData()).TenantId;
            return await base.AddAsync(entity);
        }

        public async Task<bool> ExistESubContractor(string name)
        {
            var tenant = (await _tokenService.GetTokenData()).TenantId;
            return await _dbContext.SubContractors.AnyAsync(c => c.Name == name && c.TenantId == tenant);
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
