﻿using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Percistence.Repositories
{
    public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(EventApiDbContext context, ITokenService token) : base(context, token)
    {

    }
    
       public async Task<bool> ExistEquipent(string name)=> await _dbContext.Equipment.AnyAsync(c => c.Name == name);
        
        public async Task<int> GetCount(EquipmentFilter filter)=> await GetIQuerable(filter).CountAsync();

        public async Task<List<Equipment>> GetPaged(EquipmentFilter filter, int page, int size)
        {
            var data = GetIQuerable(filter);
            var result = await data
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
        private IQueryable<Equipment> GetIQuerable(EquipmentFilter filter)
        {
            var tenantId = Task.Run(() => _tokenService.GetTokenData()).Result.TenantId;
            var data = _dbContext.Equipment.Where(c => !c.IsDeleted && c.TenantId == tenantId)
               .AsQueryable();
            data = !string.IsNullOrEmpty(filter.name) ? data.Where(c => c.Name.Contains(filter.name)) : data;
            return data;
        }
    }
}
