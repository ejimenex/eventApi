using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Application.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.AuthenticationSrv.Autenticate
{
    public class AutenticateCommandHandler:IRequestHandler<AutenticateCommand,TokenResponse>
    {
        private readonly IUserRepository _userRepository;
        public AutenticateCommandHandler(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }

        public async Task<TokenResponse> Handle(AutenticateCommand request, CancellationToken cancellationToken)
        {
            var validator = new AutenticateValidation(this._userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }
           
            var existUser = await _userRepository.ExistEmail(request.Email);
            if (!existUser)
                throw new CustomException("Wrong credentials, please check and input again");
            var user = await _userRepository.GetByEmail(request.Email);
            var passwordValid = EncryptPasswordService.VerifyPassword(request.Password,user.Password);
            if(!passwordValid)
                throw new CustomException("Wrong credentials, please check and input again");
            var token = GenerateToken.generateJwtToken(user);
            return new TokenResponse { token = token};
        }
    }
}
