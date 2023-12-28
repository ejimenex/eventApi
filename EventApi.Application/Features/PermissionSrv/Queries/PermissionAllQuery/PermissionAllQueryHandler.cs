using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.PermissionSrv.Queries.PermissionAllQuery
{
    public class PermissionAllQueryHandler(IPermissionRepository _permissionRepository, IMapper _mapper) : IRequestHandler<PermissionAllQuery, List<PemissionAllDto>>
    {

        public async Task<List<PemissionAllDto>> Handle(PermissionAllQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PemissionAllDto>>(await _permissionRepository.GetPermission());
        }
    }
}
