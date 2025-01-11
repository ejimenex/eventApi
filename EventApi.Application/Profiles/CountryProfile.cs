using AutoMapper;
using EventApi.Application.Features.CountrySrv.Queries.GetAllAsync;
using EventApi.Domain.Entities.Catalog;

namespace EventApi.Application.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, GetCountriesDto>().ReverseMap();
        }
    }
}
