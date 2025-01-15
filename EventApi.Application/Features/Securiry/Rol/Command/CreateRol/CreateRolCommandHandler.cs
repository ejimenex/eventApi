using AutoMapper;
using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.Securiry.Rol.Command.CreateRol
{
    public class CreateRolCommand : IRequest<ApiResponse<Role>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Permissions { get; set; }
    }
    public class CreateRolCommandHandler(
        IAsyncRepository<Permission> permissionRepository,
        IMapper mapper,
        IAsyncRepository<Role> roleRepository
        ) : IRequestHandler<CreateRolCommand, ApiResponse<Role>>
    {
        public async Task<ApiResponse<Role>> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            await ValidatePermission(request);
            var rol = mapper.Map<Role>(request);
            var role =  await roleRepository.AddAsync(rol);
            return new ApiResponse<Role> { Data=role,Message="Roles Addedd sucessfully"};

        }

        private async Task ValidatePermission(CreateRolCommand request)
        {
            var permissions = new List<int>();
            foreach (var item in request.Permissions)
            {
                var exist = permissionRepository.GetByExpressionAsync(c => c.Id.Equals(item)).Any();
                if (!exist)
                    permissions.Add(item);
            }
            if (permissions.Any())
                throw new SecurityException($"The following permissions do not exist: {string.Join(",", permissions)}");
        }
    }

}
