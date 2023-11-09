using MediatR;

namespace EventApi.Application.Features.CountrySrv.Queries.GetAllAsync
{
    public class GetAllCountriesQuery : IRequest<List<GetCountriesDto>>
    {

    }
}
