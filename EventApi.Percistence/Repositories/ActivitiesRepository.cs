using EventApi.Application.Contract;
using EventApi.Domain.Entities;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesRepository : BaseRepository<Activities>, IActivitiesRepository
    {
        public ActivitiesRepository(EventApiDbContext context) : base(context)
        {

        }
    }
}
