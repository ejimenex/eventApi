using MediatR;

namespace EventApi.Application.Features.AuthenticationSrv.Autenticate
{
    public class AutenticateCommand : IRequest<TokenResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
