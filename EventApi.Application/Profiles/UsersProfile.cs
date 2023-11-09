using AutoMapper;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserCommand, UserDto>().ReverseMap();
            CreateMap<User, UserCommand>().ReverseMap();
        }
    }
}
