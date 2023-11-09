using AutoMapper;
using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyPostCommand, CompanyResposeDto>().ReverseMap();
            CreateMap<Company, CompanyPostCommand>().ReverseMap();
        }
    }
}
