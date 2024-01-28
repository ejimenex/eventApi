using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using EventApi.Percistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class SubContractorRepository(EventApiDbContext context, ITokenService token) : BaseRepository<SubContractors>(context, token), ISubContractorRepository
    {
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
        private IQueryable<SubContractors> GetIQuerable(SubContractorFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.SubContractors.Where(c => !c.IsDeleted && c.TenantId == tenantId)
               .AsQueryable();

            data = !string.IsNullOrEmpty(filter.DocumentNumber) ? data.Where(c => c.DocumentNumber == filter.DocumentNumber) : data;
            data = !string.IsNullOrEmpty(filter.Name) ? data.Where(c => c.Name.Contains(filter.Name)) : data;
            return data;
        }
        public async Task<List<SubContractors>> GetPaged(SubContractorFilter filter, int page)
        {
            var data = GetIQuerable(filter);
            var result = await ExtensionsList<SubContractors>.ToPagination(data, page);
            return result;
        }
        public async Task<int> GetCount(SubContractorFilter filter) => await GetIQuerable(filter).CountAsync();

    }
}
