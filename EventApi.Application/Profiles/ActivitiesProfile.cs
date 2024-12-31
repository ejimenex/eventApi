using AutoMapper;
using EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPost;
using EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPut;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetAll;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetById;
using EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesPaged;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            CreateMap<Activities, ActivitiesPostCommand>().ReverseMap();
            CreateMap<Activities, GetAllActivitiesDto>().ReverseMap();

            CreateMap<Activities, ActivitiesPutCommand>().ReverseMap();
            CreateMap<Activities, GetActivitiesByIdDto>().ReverseMap();

            CreateMap<Activities, GetActivitiesPagesDto>()
                .ForMember(cfg => cfg.StatusName, opt => opt.MapFrom(c => c.Statu.Name))
                .ForMember(cfg => cfg.CityName, opt => opt.MapFrom(c => c.City.Name));
        }
    }
}
