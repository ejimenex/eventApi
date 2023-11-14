using AutoMapper;
using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Application.Features.SubContractorSrv.Command.PostCommand;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class SubContractorProfile : Profile
    {
        public SubContractorProfile()
        {
            CreateMap<SubContractorPostCommand, SubContractorPostCommandDto>().ReverseMap();
            CreateMap<SubContractors, SubContractorPostCommand>().ReverseMap();
        }
    }
}
