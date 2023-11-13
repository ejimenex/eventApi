using MediatR;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost
{
    public class PermissionUserPostCommand : IRequest<bool>
    {
        public string PermissionScope { get; set; }
        public int UserId { get; set; }
    }
}
