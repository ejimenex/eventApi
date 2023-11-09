using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.AuthenticationSrv.Autenticate
{
    public class AutenticateCommand:IRequest<TokenResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
