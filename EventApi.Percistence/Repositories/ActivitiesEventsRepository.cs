using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesEventsRepository : BaseRepository<ActivitiesEvents>, IActivitiesEventsRepository
    {
        public ActivitiesEventsRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }

        public override async Task<ActivitiesEvents> AddAsync(ActivitiesEvents entity)
        {
            entity.TenantId = (await _tokenService.GetTokenData()).TenantId;
            return await base.AddAsync(entity);
        }
      
    }
}
