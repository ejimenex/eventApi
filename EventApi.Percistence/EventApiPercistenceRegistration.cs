using EventApi.Application.Contract;
using EventApi.Application.Contract.Persistence;
using EventApi.Percistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventApi.Percistence
{
    public static class EventApiPercistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventApiDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("Context")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
