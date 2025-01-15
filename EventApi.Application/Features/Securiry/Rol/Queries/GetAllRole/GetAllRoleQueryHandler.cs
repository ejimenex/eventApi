using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Contract.Persistence;
using EventApi.Application.Features.UsersSrv.Queries.GetAllUser;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Extension;
using EventApi.Infrasestructure.Filters;
using EventApi.Infrasestructure.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.Securiry.Rol.Queries.GetAllRole
{
    public class  GetAllRoleQuery:IRequest<ApiResponse<RoleVM>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public RoleFilter Filters { get; set; }
    }
    public class GetAllRoleQueryHandler(IAsyncRepository<Role> roleRepository,IMapper mapper, ITokenService tokenService) : IRequestHandler<GetAllRoleQuery, ApiResponse<RoleVM>>
    {
        public async Task<ApiResponse<RoleVM>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            
            var role = await Task.Run(() => 

              roleRepository.GetByExpressionAsync(c => !c.IsDeleted && c.TenantId == tokenService.GetTokenData().Result.TenantId)
                      .WhereIf(request.Filters.Description is not null, c => c.Description.Contains(request.Filters.Description.Trim()))
                      .WhereIf(request.Filters.Name is not null, c => c.Name.Contains(request.Filters.Name.Trim()))
            );
            var data = mapper.Map<List<RoleDto>>(role.PaginateResult(request.Page,request.Size));

            var result = new RoleVM()
            {
                Count = role.Count(),
                Size = Math.Min(request.Size, 10),
                Page = Math.Max(request.Page, 1),
                Data = data
            };
            return new ApiResponse<RoleVM> { Message = string.Empty, Data = result };
        }
    }
}
