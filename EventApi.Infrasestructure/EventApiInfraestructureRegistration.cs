using EventApi.Infrasestructure.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Infrasestructure
{
    public static class EventApiInfraestructureRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection service)
        {
            service.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            service.AddTransient<ITokenService, TokenRepository>();
            return service;
        }
    }
}
