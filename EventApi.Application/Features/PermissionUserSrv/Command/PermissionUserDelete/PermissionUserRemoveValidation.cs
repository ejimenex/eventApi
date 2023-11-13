using EventApi.Application.Contract;
using EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserDelete;
using FluentValidation;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost
{
    public class PermissionUserRemoveValidation : AbstractValidator<PermissionUserDeleteCommand>
    {

        private readonly IPermissionUserRepository _permissionUserRepository;
        public PermissionUserRemoveValidation(IPermissionUserRepository permissionUserRepository)
        {
            _permissionUserRepository = permissionUserRepository;
            RuleFor(p => p.Id).NotEqual(0).WithMessage("Id it is required");
            RuleFor(c => c).MustAsync(ValidateExist).WithMessage("Id does not exist");
        }
        private async Task<bool> ValidateExist(PermissionUserDeleteCommand e, CancellationToken token) => (await _permissionUserRepository.ExistId(e.Id));
    }
}
