using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost;
using MediatR;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserDelete
{
    public class PermissionUserRemoveCommandHandler : IRequestHandler<PermissionUserDeleteCommand, bool>
    {
        private readonly IPermissionUserRepository _permissionUserRepository;
        public PermissionUserRemoveCommandHandler(IPermissionUserRepository permissionUserRepository)
        {
            _permissionUserRepository = permissionUserRepository;
        }

        public async Task<bool> Handle(PermissionUserDeleteCommand request, CancellationToken cancellationToken)
        {
            var validator = new PermissionUserRemoveValidation(_permissionUserRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }
            await _permissionUserRepository.Remove(request.Id);
            return true;
        }
    }
}
