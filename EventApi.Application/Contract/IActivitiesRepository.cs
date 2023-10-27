using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Contract
{
    public interface IActivitiesRepository : IAsyncRepository<Activities>
    {
    }
}
