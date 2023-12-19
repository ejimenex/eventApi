using MediatR;

namespace EventApi.Application.Features.EquipmentSrv.Command.PutCommand
{
    public class EquipmentPutCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
