using AutoMapper;
using EventApi.Application.Features.PermissionSrv.Queries.PermissionAllQuery;
using EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PemissionAllDto>().ReverseMap();

            CreateMap<PermissionUser, PermissionUserPostCommand>().ReverseMap();
        }
    }
}
