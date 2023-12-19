using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.EquipmentSrv.Command.PostCommand
{
    public class EquipmentPostCommand : IRequest<ApiResponse<EquipmentPostCommandDto>>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
