using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.UsersSrv.Command.Post
{
    public class UserCommand : IRequest<ApiResponse<UserDto>>
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? OcupationId { get; set; }
        public Guid TenantId { get; set; }
        public string LanguageCode { get; set; }
    }
}
