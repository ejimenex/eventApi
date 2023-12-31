﻿using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
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
        private IQueryable<SubContractors> GetIQuerable(SubContractorFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.SubContractors.Where(c => !c.IsDeleted && c.TenantId == tenantId)
               .AsQueryable();

            data = !string.IsNullOrEmpty(filter.DocumentNumber) ? data.Where(c => c.DocumentNumber == filter.DocumentNumber) : data;
            data = !string.IsNullOrEmpty(filter.Name) ? data.Where(c => c.Name.Contains(filter.Name)) : data;
            return data;
        }
        public async Task<List<SubContractors>> GetPaged(SubContractorFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
        public async Task<int> GetCount(SubContractorFilter filter) => await GetIQuerable(filter).CountAsync();

    }
}
