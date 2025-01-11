using AutoMapper;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Application.Features.UsersSrv.Queries.GetAllUser;
using EventApi.Domain.Entities.Security;

namespace EventApi.Application.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserCommand, UserDto>().ReverseMap();
            CreateMap<User, UserCommand>().ReverseMap();

            CreateMap<User, GetAllUserDto>()
                .ForMember(c => c.Ocupation, opt => opt.MapFrom(c => c.Ocupation.Name));
        }
    }
}
