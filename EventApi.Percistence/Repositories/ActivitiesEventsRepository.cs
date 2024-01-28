using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Percistence.Repositories.Base;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesEventsRepository(EventApiDbContext context, ITokenService token) : BaseRepository<ActivitiesEvents>(context, token), IActivitiesEventsRepository
    {
        public override async Task<ActivitiesEvents> AddAsync(ActivitiesEvents entity)
        {
            entity.TenantId = (await _tokenService.GetTokenData()).TenantId;
            return await base.AddAsync(entity);
        }

    }
}
