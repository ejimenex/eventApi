using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.PermissionUserSrv.Command.PermissionUserPost
{
    public class PermissionUserPostCommandHandler(IPermissionUserRepository _permissionUserRepository, IMapper _mapper) : IRequestHandler<PermissionUserPostCommand, bool>
    {

        public async Task<bool> Handle(PermissionUserPostCommand request, CancellationToken cancellationToken)
        {
            var validator = new PermissionUserPostValidation(_permissionUserRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }
            var entity = _mapper.Map<PermissionUser>(request);
            await _permissionUserRepository.Add(entity);
            return true;
        }
    }
}
