using MediatR;

namespace EventApi.Application.Features.PermissionSrv.Queries.PermissionAllQuery
{
    public class PermissionAllQuery : IRequest<List<PemissionAllDto>>
    {
    }
}
