using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Percistence.Repositories
{
    public class ActivitiesRepository : BaseRepository<Activities>, IActivitiesRepository
    {
        public ActivitiesRepository(EventApiDbContext context):base(context) 
        {
                
        }
    }
}
