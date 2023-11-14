using AutoMapper;
using EventApi.Application.Features.SubContractorSrv.Command.PostCommand;
using EventApi.Application.Features.SubContractorSrv.Command.PutCommand;
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
        }
    }
}
