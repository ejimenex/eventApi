using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Percistence.Repositories.Base;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesRepository : BaseRepository<Activities>, IActivitiesRepository
    {
        public ActivitiesRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }
    }
}
