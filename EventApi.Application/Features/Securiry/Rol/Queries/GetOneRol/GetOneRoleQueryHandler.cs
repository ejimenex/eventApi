using AutoMapper;
using EventApi.Application.Contract.Persistence;
using EventApi.Application.Exceptions;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.Securiry.Rol.Queries.GetOneRol
{
    public class GetOneRoleQuery:IRequest<ApiResponse<RoleOneDto>>
    {
        public Guid UniqueId { get; set; }
    }
    public class GetOneRoleQueryHandler(IAsyncRepository<Role> roleRepository, IMapper mapper) : IRequestHandler<GetOneRoleQuery, ApiResponse<RoleOneDto>>
    {
        public async Task<ApiResponse<RoleOneDto>> Handle(GetOneRoleQuery request, CancellationToken cancellationToken)
        {
           var rol = await Task.Run(()=> roleRepository.GetWithInclude(c=> c.UniqueId.Equals(request.UniqueId),c=> c.RolPermission).FirstOrDefault())
           ?? throw new CustomException("No Role");
            var data = mapper.Map<RoleOneDto>(rol);
            return new ApiResponse<RoleOneDto> { Message = string.Empty, Data = data };

        }
    }
}
