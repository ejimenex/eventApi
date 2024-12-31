using AutoMapper;
using EventApi.Application.Features.CitySrv.Command.CreateCommand;
using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityPostCommand, City>().ReverseMap();
        }
    }
}
