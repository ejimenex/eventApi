using AutoMapper;
using EventApi.Application.Features.EquipmentSrv.Command.PostCommand;
using EventApi.Application.Features.EquipmentSrv.Command.PutCommand;
using EventApi.Application.Features.EquipmentSrv.Queries.GetAllAsync;
using EventApi.Application.Features.EquipmentSrv.Queries.GetByIdAsync;
using EventApi.Domain.Entities;

namespace EventApi.Application.Profiles
{
    public class EquipemntProfile : Profile
    {
        public EquipemntProfile()
        {
            CreateMap<EquipmentPostCommand, EquipmentPostCommandDto>().ReverseMap();
            CreateMap<Equipment, EquipmentPostCommand>().ReverseMap();

            CreateMap<Equipment, EquipmentPutCommand>().ReverseMap();

            CreateMap<Equipment, GetAllEquipmentDto>().ReverseMap();
            CreateMap<Equipment, EquipmentByIdDto>();
        }
    }
}
