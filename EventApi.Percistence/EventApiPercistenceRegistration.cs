using EventApi.Application.Contract;
using EventApi.Application.Contract.Persistence;
using EventApi.Percistence.Repositories;
using EventApi.Percistence.Repositories.Base;
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
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionUserRepository, PermissionUserRepository>();
            services.AddScoped<ISubContractorRepository, SubContractorRepository>();
            services.AddScoped<IOcupationRepository, OcupationRepository>();
            services.AddScoped<IActivitiesEventsRepository, ActivitiesEventsRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();

            return services;
        }
    }
}
