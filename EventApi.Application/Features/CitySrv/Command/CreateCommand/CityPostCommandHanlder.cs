using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.CitySrv.Command.CreateCommand
{
    public class CityPostCommandHanlder(IMapper _mapper, ICityRepository _cityRepository,ICountryRepository _countryRepository) : IRequestHandler<CityPostCommand, Unit>
    {
        public async Task<Unit> Handle(CityPostCommand request, CancellationToken cancellationToken)
        {
            await Vaidation(request);
            var entity = _mapper.Map<City>(request);
            await _cityRepository.AddAsync(entity);
            return Unit.Value;
        }
        private async Task Vaidation(CityPostCommand request) {
            if (!await _countryRepository.ExistId(request.CountryId.Value))
            {
                throw new CustomException("This country doesn't exist");
            }
        }
    }
}
