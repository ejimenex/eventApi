using AutoMapper;
using EventApi.Application.Features.OcupationSrv.Queries.GetByIdAsync;
using EventApi.Application.Features.SubContractorSrv.Command.PostCommand;
using EventApi.Application.Features.SubContractorSrv.Command.PutCommand;
using EventApi.Application.Features.SubContractorSrv.Queries.GetAllAsync;
using EventApi.Application.Features.SubContractorSrv.Queries.GetByIdAsync;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class SubContractorProfile : Profile
    {
        public SubContractorProfile()
        {
            CreateMap<SubContractorPostCommand, SubContractorPostCommandDto>().ReverseMap();
            CreateMap<SubContractors, SubContractorPostCommand>().ReverseMap();

            CreateMap<SubContractors, SubContractorPutCommand>().ReverseMap();

            CreateMap<SubContractors, GetAllSusContractorDto>().ReverseMap();
            CreateMap<SubContractors, SubContractorByIdDto>();
        }
    }
}
