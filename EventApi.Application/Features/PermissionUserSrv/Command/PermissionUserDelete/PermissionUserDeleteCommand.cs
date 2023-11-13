using MediatR;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserDelete
{
    public class PermissionUserDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
