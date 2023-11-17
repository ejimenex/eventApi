using AutoMapper;
using EventApi.Application.Features.OcupationSrv.Command;
using EventApi.Application.Features.OcupationSrv.Command.OcupationPutCommand;
using EventApi.Application.Features.OcupationSrv.Queries.GetAllAsync;
using EventApi.Application.Features.OcupationSrv.Queries.GetByIdAsync;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class OcupationProfile : Profile
    {
        public OcupationProfile()
        {
            CreateMap<OcupationPostCommand, OcupationrPostCommandDto>().ReverseMap();
            CreateMap<Ocupation, OcupationPostCommand>().ReverseMap();

            CreateMap<Ocupation, OcupationPutCommand>().ReverseMap();

            CreateMap<Ocupation, GetAllOcupationDto>().ReverseMap();

            CreateMap<Ocupation, GetOcupationByIdDto>().ReverseMap();
        }
    }
}
