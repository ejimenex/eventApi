using EventApi.Application.Contract;
using FluentValidation;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost
{

    public class PermissionUserPostValidation : AbstractValidator<PermissionUserPostCommand>
    {

        private readonly IPermissionUserRepository _permissionUserRepository;
        public PermissionUserPostValidation(IPermissionUserRepository permissionUserRepository)
        {
            _permissionUserRepository = permissionUserRepository;
            RuleFor(p => p.PermissionScope).NotEmpty().WithMessage("Scope is Required");
            RuleFor(p => p.UserId).NotEqual(0).WithMessage("User it is required");
            RuleFor(c => c).MustAsync(ValidateUserExist).WithMessage("This user does not exist");
            RuleFor(c => c).MustAsync(ValidateScopeExist).WithMessage("This Scope does not exist");
            RuleFor(c => c).MustAsync(ValidateExist).WithMessage("Already exist one row with this scope and this user");
        }
        private async Task<bool> ValidateExist(PermissionUserPostCommand e, CancellationToken token) => (await _permissionUserRepository.Exist(e.UserId, e.PermissionScope));
        private async Task<bool> ValidateUserExist(PermissionUserPostCommand e, CancellationToken token) => (await _permissionUserRepository.ExistUser(e.UserId));
        private async Task<bool> ValidateScopeExist(PermissionUserPostCommand e, CancellationToken token) => (await _permissionUserRepository.ExistScope(e.PermissionScope));
    }
}

