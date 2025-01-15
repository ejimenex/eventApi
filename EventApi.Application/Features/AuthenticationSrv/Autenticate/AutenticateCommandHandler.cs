using EventApi.Application.Contract;
using EventApi.Application.Contract.Persistence;
using EventApi.Application.Exceptions;
using EventApi.Application.Utils;
using EventApi.Domain.Entities.Security;
using MediatR;
using System.Linq;

namespace EventApi.Application.Features.AuthenticationSrv.Autenticate
{
    public class AutenticateCommandHandler(
        IUserRepository userRepository,
        IPermissionUserRepository permissionUserRepository,
        IAsyncRepository<UserRole> userRoleRepository,
        IAsyncRepository<RolPermission> rolPermissionRepository,
        IAsyncRepository<UserAdittionalPermission> additionalPermissionRepository) : IRequestHandler<AutenticateCommand, TokenResponse>
    {
        public async Task<TokenResponse> Handle(AutenticateCommand request, CancellationToken cancellationToken)
        {
            var existUser = await userRepository.ExistEmail(request.Email);
            if (!existUser)
                throw new CustomException("Wrong credentials, please check and input again");
            var user = await userRepository.GetByEmail(request.Email);
            var passwordValid = EncryptPasswordService.VerifyPassword(request.Password, user.Password);

            if (!passwordValid)
                throw new CustomException("Wrong credentials, please check and input again");
            var permissions = (await GetPermission(user.Id));
            var token = GenerateToken.generateJwtToken(user, permissions.ToList());
            await UpdateLoginUserData(user.Id);
            return new TokenResponse { token = token };
        }
        private async Task <List<string>> GetPermission(int userId) {
            var roles = 
                userRoleRepository.GetByExpressionAsync(c => c.UserId.Equals(userId) && !c.IsDeleted)
                .Select(c=> c.RolId.ToString())
                .ToList();
            if (!roles.Any())
                throw new CustomException("This user does not have roles jet");
            var permissions = 
                rolPermissionRepository
                .GetWithInclude(c => roles.Contains(c.RolId.ToString()) && !c.IsDeleted, c=> c.Permission)
                .Select(c=> c.Permission.Scope)
                .ToList();
            var addionalPermissions = 
                additionalPermissionRepository
                .GetWithInclude(c => c.UserId.Equals(userId) && !c.IsDeleted, c => c.Permission)
                .Select(c => c.Permission.Scope)
                .ToList();
            var permssions = permissions.Concat(addionalPermissions)
                .Distinct()
                .ToList();
            return permssions;

        }
        private async Task UpdateLoginUserData(int userId) {
        var user = await userRepository.GetByIdAsync(userId);
            user.LastLogin = DateTime.Now;
            user.LoginQuantity =+ 1;
           await    userRepository.UpdateAsync(user);
        }
    }
}
