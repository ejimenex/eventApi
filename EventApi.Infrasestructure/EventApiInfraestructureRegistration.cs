using EventApi.Infrasestructure.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
