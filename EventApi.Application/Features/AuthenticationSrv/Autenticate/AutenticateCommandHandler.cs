using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Application.Utils;
using MediatR;

namespace EventApi.Application.Features.AuthenticationSrv.Autenticate
{
    public class AutenticateCommandHandler(IUserRepository userRepository, IPermissionUserRepository permissionUserRepository) : IRequestHandler<AutenticateCommand, TokenResponse>
    {
        public async Task<TokenResponse> Handle(AutenticateCommand request, CancellationToken cancellationToken)
        {
            var validator = new AutenticateValidation(userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }

            var existUser = await userRepository.ExistEmail(request.Email);
            if (!existUser)
                throw new CustomException("Wrong credentials, please check and input again");
            var user = await userRepository.GetByEmail(request.Email);
            var passwordValid = EncryptPasswordService.VerifyPassword(request.Password, user.Password);

            if (!passwordValid)
                throw new CustomException("Wrong credentials, please check and input again");
            var permissions = (await permissionUserRepository.GetByUser(user.Id)).Select(c => c.PermissionScope);
            var token = GenerateToken.generateJwtToken(user, permissions.ToList());
            return new TokenResponse { token = token };
        }
    }
}
