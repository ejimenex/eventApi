using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost;
using MediatR;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserDelete
{
    public class PermissionUserRemoveCommandHandler(IPermissionUserRepository _permissionUserRepository) : IRequestHandler<PermissionUserDeleteCommand, bool>
    {

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
