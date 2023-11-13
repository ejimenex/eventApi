using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.PermissionSrv.Queries.PermissionAllQuery
{
    public class PermissionAllQueryHandler : IRequestHandler<PermissionAllQuery, List<PemissionAllDto>>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionAllQueryHandler(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<List<PemissionAllDto>> Handle(PermissionAllQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PemissionAllDto>>(await _permissionRepository.GetPermission());
        }
    }
}
