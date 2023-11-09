using AutoMapper;
using EventApi.Application.Contract;
using MediatR;

namespace EventApi.Application.Features.CountrySrv.Queries.GetAllAsync
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<GetCountriesDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        public GetAllCountriesQueryHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCountriesDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<GetCountriesDto>>(await _countryRepository.GetCountries());
        }
    }
}
